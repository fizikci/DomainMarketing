using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using DealerSafe2.API.Entity.Jobs;
using DealerSafe2.DTO;
using DealerSafe2.DTO.Enums;
using DealerSafe2.DTO.Request;
using DealerSafe2.DTO.Response;
using rfl = System.Reflection;
using System.Web;
using DealerSafe2.API.Entity.Orders;
using DealerSafe2.DTO.EntityInfo.Products.SSL;
using DealerSafe2.API.Entity.Products.SSL;
using DealerSafe2.API.Entity.Products;

namespace DealerSafe2.API
{
    public partial class ApiJson
    {
        /// <summary>
        /// Sitede "my products" listesini sağlayan method
        /// </summary>
        public List<ListViewMemberSSLInfo> GetMemberSSLList(ReqEmpty req)
        {
            return Provider.Database.GetDataTable(@"
                        SELECT 
                            ssl.Id,
                            ssl.InsertDate,
                            mp.OrderItemId,
                            oi.OrderId,
                            oi.DisplayName AS ProductName,
                            ssl.State,
                            ssl.DomainName
                        FROM 
                            MemberSSL ssl
                            INNER JOIN MemberProduct mp ON ssl.Id = mp.Id
                            INNER JOIN OrderItem oi ON mp.OrderItemId = oi.Id
                            INNER JOIN [Order] o ON o.Id = oi.OrderId AND o.MemberId = {0} AND o.State = 'Order';", Session.MemberId)
                   .ToEntityList<ListViewMemberSSLInfo>();
        }

        public string GetLastMemberSSLId(ReqEmpty req)
        {
            return Provider.Database.GetString(@"select top 1
                            ssl.Id
                        from 
                            MemberSSL ssl
                            INNER JOIN MemberProduct mp ON ssl.Id = mp.Id
                            inner join OrderItem oi ON mp.OrderItemId = oi.Id
                            inner join [Order] o ON o.Id = oi.OrderId AND o.MemberId = {0}
                        where
	                        ssl.State = 'None';", Session.MemberId);
        }

        /// <summary>
        /// id'si ile memberSSL kaydını döndüren method
        /// </summary>
        public MemberSSLInfo GetMemberSSL(string memberSSLId)
        {
            return Provider.Database.Read<MemberSSL>("Id={0}", memberSSLId).ToEntityInfo<MemberSSLInfo>();
        }

        /// <summary>
        /// 1. adım: verilen CSR'ın içindeki bilgileri döndüren method
        /// </summary>
        /// <param name="req">CSR kodu ile doldurulmuş ReqDecodeCSR</param>
        public ResDecodeCSR DecodeCSR(ReqDecodeCSR req)
        {
            // Javascript csr kodunu gönderirken + sembollerini boşluk olarak gönderdiğinden burada eski haline çeviriyorum
            req.csr = req.csr.Replace(" ", "+");

            return ComodoDecodeCSR(req);
        }

        /// <summary>
        /// 2. adım: kullanıcı hangi email adresi ile validasyon yapacağını seçsin
        /// </summary>
        public List<string> GetDVEmailAddressList(string domainName)
        {
            return ComodoGetDcvEmailAddressList(domainName).ToList();
        }

        /// <summary>
        /// 3. adım: toplanan bilgileri MemberSSL'e kaydet
        /// </summary>
        public bool SaveMemberSSLInfo(MemberSSLInfo req)
        {
            try
            {
                Provider.Database.Begin();

                var memberProduct = Provider.Database.Read<MemberProduct>("OrderItemId={0}", req.OrderItemId) ?? new MemberProduct();
                req.CopyPropertiesWithSameName(memberProduct);
                memberProduct.Save();

                var memberSSL = Provider.Database.Read<MemberSSL>("Id={0}", memberProduct.Id) ?? new MemberSSL();
                req.CopyPropertiesWithSameName(memberSSL);
                memberSSL.DomainName = memberSSL.CsrCN;
                memberSSL.State = SSLStates.CSRReceived;
                if (memberSSL.Id.IsEmpty()) {
                    memberSSL.Id = memberProduct.Id;
                    Provider.Database.Insert("MemberSSL", memberSSL);
                }
                else
                    memberSSL.Save();

                // WorkerSSL.CreateJobsFor(order) ile kullanıcıya bir Job atamıştık. (yani Executer=Member) Bu adımda kullanıcı görevini yapmış oluyor. Artık bu Job'ı Machine'e atayabiliriz.
                var job = Provider.Database.Read<Job>("RelatedEntityName={1} AND RelatedEntityId={0}", memberProduct.OrderItemId, "OrderItem");
                job.StartDate = Provider.Database.Now;
                job.Executer = JobExecuters.Machine;
                job.State = JobStates.NotStarted;
                job.Save();

                Provider.Database.Commit();

                return true;
            }
            catch (Exception ex)
            {
                Provider.Database.Rollback();

                throw new APIException(ex.Message, ErrorTypes.SystemError);
            }
        }

        /// <summary>
        /// JobCommands.SSLGenerate: MemberSSL'de toplanan bilgileri Comodo'ya gönder
        /// </summary>
        public MemberSSLInfo GenerateSSL(MemberSSLInfo req)
        {
            var orderItem = Provider.Database.Read<OrderItem>("Id={0}", req.OrderItemId);

            var comodoRes = ComodoAutoApplySSL(new ReqComodoAutoApplySSL()
            {
                csr = req.ReqCSRCode,
                streetAddress1 = req.CsrStreet,
                postalCode = req.CsrPostalCode,
                dcvEmailAddress = req.ReqDCVEmail,
                dcvMethod = ComodoDcvMethod.EMAIL,
                emailAddress = req.ReqEmail,
                product = orderItem.Product().SupplierProductRefNo,
                serverSoftware = ComodoServerSoftware.Other,
                servers = 100,
                years = orderItem.Amount,
                caCertificateID = 635

            });

            var memProd = Provider.Database.Read<MemberProduct>("OrderItemId={0}", req.OrderItemId);
            memProd.StartDate = Provider.Database.Now;
            memProd.EndDate = Provider.Database.Now.AddYears(orderItem.Amount);
            memProd.CurrentPhase = LifeCyclePhases.Active;
            memProd.Save();

            var memberSSL = Provider.Database.Read<MemberSSL>("Id={0}", memProd.Id);
            memberSSL.ResCertificateId = comodoRes.certificateID;
            memberSSL.ResCertificateStatus = comodoRes.certificateStatus;
            memberSSL.ResOrderNumber = comodoRes.orderNumber;
            memberSSL.ResTotalCost = comodoRes.totalCost;
            memberSSL.State = SSLStates.SentToCA;
            memberSSL.Save();

            var res = memberSSL.ToEntityInfo<MemberSSLInfo>();
            memProd.CopyPropertiesWithSameName(res);

            return res;
        }

        /// <summary>
        /// JobCommands.SSLUpdateDCV: Member validation email adresini değiştirmek istiyorsa
        /// </summary>
        public ResUpdateDCV UpdateDCV(ReqUpdateDCV req)
        {
            return ComodoAutoUpdateDCV(req);
        }

        /// <summary>
        /// JobCommands.SSLCheckResult: 
        /// </summary>
        public ResCollectSSL CollectSSL(string orderItemId)
        {
            if (string.IsNullOrWhiteSpace(orderItemId)) return null;

            var memberSSL = Provider.Database.Read<MemberSSL>("Id={0}", Provider.Database.GetString("SELECT Id FROM MemberProduct WHERE OrderItemId={0}", orderItemId));
            if (memberSSL == null) return null;

            ReqCollectSSL reqCollectSSL = new ReqCollectSSL
            {
                certificateId = memberSSL.ResCertificateId,
                orderNumber = memberSSL.ResOrderNumber,
                responseEncoding = ComodoResponseEncoding.BASE64,
                responseType = ComodoResponseType.ZipArchive
            };

            var resComodoCollectSSL = ComodoCollectSSL(reqCollectSSL);

            return resComodoCollectSSL;
        }



        #region SSL tools

        /// <summary>
        /// Verilen domain için sertifika durumunu sorgular
        /// </summary>
        public ResSSLChecker SSLCheckDomain(string domainName)
        {
            return ComodoSSLCheckDomain(domainName);
        }

        public ResCertificateKeyMatcher CertificateMatch(ReqCertificateKeyMatcher req)
        {
            ResCertificateKeyMatcher response = new ResCertificateKeyMatcher();

            req.Certificate = req.Certificate.Replace(" ", "+").Replace("BEGIN+CERTIFICATE", "BEGIN CERTIFICATE").Replace("END+CERTIFICATE", "END CERTIFICATE");
            req.CSROrPrivateKey = req.CSROrPrivateKey.Replace(" ", "+").Replace("BEGIN+CERTIFICATE+REQUEST", "BEGIN CERTIFICATE REQUEST").Replace("END+CERTIFICATE+REQUEST", "END CERTIFICATE REQUEST");
            req.CSROrPrivateKey = req.CSROrPrivateKey.Replace(" ", "+").Replace("BEGIN+RSA+PRIVATE+KEY", "BEGIN RSA PRIVATE KEY").Replace("END+RSA+PRIVATE+KEY", "END RSA PRIVATE KEY");

            // Alınan certificate text, OpenSSL işlemesi için dosya haline getirilir
            var certFilePath = string.Format("{0}{1}.crt", ConfigurationManager.AppSettings["opensslTmpPath"], DateTime.Now.Ticks);
            File.WriteAllText(certFilePath, req.Certificate);
            
            // Certificate Hash
            string certificateHashOutput = ExecuteOpenSSL(string.Format("x509 -noout -modulus -in {0}", certFilePath));
            if (!certificateHashOutput.Contains(":error"))
            {
                response.CertificateHash = certificateHashOutput.Replace("Modulus=", string.Empty).Trim();

            }

            // Oluşturulan dosyayı yer kaplamasın diye siliyorum #YalcinG
            File.Delete(certFilePath);


            // Alınan certificate text, OpenSSL işlemesi için dosya haline getirilir
            var csrOrPrivateKeyFilePath = string.Format("{0}{1}.key", ConfigurationManager.AppSettings["opensslTmpPath"], DateTime.Now.Ticks);
            File.WriteAllText(csrOrPrivateKeyFilePath, req.CSROrPrivateKey);

            // Private Key or CSR Hash
            string csrOrPrivateKeyOutput = ExecuteOpenSSL(req.MatchType == "privateKey" ? string.Format("rsa -noout -modulus -in {0}", csrOrPrivateKeyFilePath) : string.Format("req -noout -modulus -in {0}", csrOrPrivateKeyFilePath));
            if (!csrOrPrivateKeyOutput.Contains(":error"))
            {
                response.CSROrPrivateKeyHash = csrOrPrivateKeyOutput.Replace("Modulus=", string.Empty).Trim();
            }
            // Oluşturduğum csr veya private kley dosyasını diskte yer kaplamasın diye geri siliyorum
            File.Delete(csrOrPrivateKeyFilePath);

            // Dosya modulus hashlerini kontrol ederek birbirine ait olup olmadığına bakıyorum
            response.IsMatch = !string.IsNullOrEmpty(response.CSROrPrivateKeyHash) && Equals(response.CSROrPrivateKeyHash, response.CertificateHash);

            return response;
        }

        /// <summary>
        /// Verilen certificate bilgilerini çözer
        /// </summary>
        public ResSSLCertificateInfo DecodeCertificate(string certificate)
        {
            certificate = certificate.Replace(" ", "+").Replace("BEGIN+CERTIFICATE", "BEGIN CERTIFICATE").Replace("END+CERTIFICATE", "END CERTIFICATE");
            string opensslTmpFile = string.Format("{0}{1}.cer", ConfigurationManager.AppSettings["opensslTmpPath"], certificate.MD5());
            //string opensslTmpFile = string.Format("{0}{1}.cer", ConfigurationManager.AppSettings["opensslTmpPath"], "test");

            // Alınan certificate text, OpenSSL işlemesi için dosya haline getirilir
            File.WriteAllText(opensslTmpFile, certificate);

            ResSSLCertificateInfo certificateInfo = new ResSSLCertificateInfo();
            string processOutput = ExecuteOpenSSL(string.Format("x509 -in {0} -noout -issuer -subject -email -dates -serial -fingerprint", opensslTmpFile));

            string[] lines = processOutput.Split('\n');
            foreach (string line in lines.Where(line => line.Contains("=")))
            {
                string[] tmp = line.Split('=');
                string command = tmp[0];
                string value = tmp[1];

                switch (command)
                {
                    case "serial":
                        certificateInfo.serial = value;
                        break;
                    case "issuer":
                        string[] issuerTmp = line.Split('/');


                        var issuer = new Issuer();
                        foreach (string s in issuerTmp.Where(s => s.Contains("=")))
                        {
                            string issuerCommand = s.Split('=')[0];
                            string issuerValue = s.Split('=')[1];

                            switch (issuerCommand)
                            {
                                case "C":
                                    issuer.C = issuerValue;
                                    break;
                                case "CN":
                                    issuer.CN = issuerValue;
                                    break;
                                case "L":
                                    issuer.L = issuerValue;
                                    break;
                                case "O":
                                    issuer.O = issuerValue;
                                    break;
                                case "ST":
                                    issuer.ST = issuerValue;
                                    break;
                            }
                        }

                        certificateInfo.issuer = issuer;
                        break;
                    case "subject":
                        string[] subjectTmp = line.Split('/');


                        var subject = new Subject();
                        foreach (string s in subjectTmp.Where(s => s.Contains("=")))
                        {
                            string subjectCommand = s.Split('=')[0];
                            string subjectValue = s.Split('=')[1];

                            switch (subjectCommand)
                            {
                                case "C":
                                    subject.C = subjectValue;
                                    break;
                                case "CN":
                                    subject.CN = subjectValue;
                                    break;
                                case "L":
                                    subject.L = subjectValue;
                                    break;
                                case "O":
                                    subject.O = subjectValue;
                                    break;
                                case "ST":
                                    subject.ST = subjectValue;
                                    break;
                            }
                        }

                        certificateInfo.subject = subject;
                        break;
                    case "notBefore":
                        certificateInfo.notBefore = value;
                        break;
                    case "notAfter":
                        certificateInfo.notAfter = value;
                        break;
                }
            }

            // Oluşturulan temp certificate dosyası silinir #YalcinG
            File.Delete(opensslTmpFile);

            return certificateInfo;
        }

        /// <summary>
        /// Sertifikaları birbirine (der to pfx, cer to pkcs12 vb) çevirir
        /// </summary>
        public ResConvertCertificate ConvertCertificate(ReqConvertCertificate req)
        {
            ResConvertCertificate resConvertCertificate = new ResConvertCertificate();

            string inputPath = ConfigurationManager.AppSettings.Get("opensslTmpPath");
            string inputFile = req.SourceFileName;
            string inputFullFilename = inputPath + inputFile;

            string outputPath = ConfigurationManager.AppSettings.Get("opensslTmpPath");
            string outputFile = req.DestinationFileName;
            string outputFullFilename = outputPath + outputFile;

            switch (req.CertificateConvertType)
            {
                case ConvertType.PEMtoDER:
                    ExecuteOpenSSL(string.Format("x509 -outform der -in {0} -out {1}", inputFullFilename, outputFullFilename));
                    break;
                case ConvertType.PEMtoP7B:
                    ExecuteOpenSSL(string.Format("crl2pkcs7 -nocrl -certfile {0} -out {1}", inputFullFilename, outputFullFilename));
                    break;
                case ConvertType.PEMtoPFX:
                    ExecuteOpenSSL(string.Format("pkcs12 -export -out {0} -inkey C:\\Users\\Yalcin\\Desktop\\test_private.key -in {1} -certfile C:\\Users\\Yalcin\\Desktop\\test_ca.crt", outputFullFilename, inputFullFilename));
                    // TODO: Oluşturulan dosyayı download et #YalcinG
                    break;
                case ConvertType.DERtoPEM:
                    ExecuteOpenSSL(string.Format("x509 -inform der -in {0} -out {1}", inputFullFilename, outputFullFilename));
                    break;
                case ConvertType.P7BtoPEM:
                    ExecuteOpenSSL(string.Format("pkcs7 -print_certs -in {0} -out {1}", inputFullFilename, outputFullFilename));
                    break;
                case ConvertType.P7BtoPFX:
                    ExecuteOpenSSL(string.Format("pkcs7 -print_certs -in {0} -out {1}", inputFullFilename, outputFullFilename));
                    //ExecuteOpenSSL("pkcs12 -export -in certificate.cer -inkey privateKey.key -out certificate.pfx -certfile CACert.cer");
                    break;
                case ConvertType.PFXtoPEM:
                    ExecuteOpenSSL(string.Format("pkcs12 -in {0} -out {1} -nodes", inputFullFilename, outputFullFilename));
                    break;
            }

            File.Delete(inputFullFilename);

            string fileName = req.DestinationFileName.Substring(0, req.DestinationFileName.LastIndexOf('.'));
            string fileExt = req.DestinationFileName.Substring(req.DestinationFileName.LastIndexOf('.') + 1);

            resConvertCertificate.DownloadUrl = string.Format("/PaymentGateway/DownloadConvertedFile.ashx?file={0}&ext={1}", fileName, fileExt);
            return resConvertCertificate;
        }

        /*
         - Certificate Key Matcher -
           openssl x509 -noout -modulus -in certificate.crt | openssl md5
           openssl rsa -noout -modulus -in privateKey.key | openssl md5
           openssl req -noout -modulus -in CSR.csr | openssl md5
         */
        #endregion

        #region Comodo
        // Config dosyasından kullanıcı adı ve şifresini alır
        readonly string _comodoUsername = ConfigurationManager.AppSettings.Get("comodoUsername");
        readonly string _comodoPassword = ConfigurationManager.AppSettings.Get("comodoPassword");

        /// <summary>
        /// SSL sertifikası satın alır (Generate)
        /// </summary>
        private ResComodoAutoApplySSL ComodoAutoApplySSL(ReqComodoAutoApplySSL req)
        {
            // TODO: Debug için comodo'ya göndermeden boş değer gönderiyoruz
            //return new ResComodoAutoApplySSL()
            //{
            //    certificateID = "0",
            //    certificateStatus = "Completed",
            //    expectedDeliveryTime = "1",
            //    orderNumber = "1",
            //    totalCost = "0"
            //};
            req.csr = req.csr.Replace(" ", "+");

            ResComodoAutoApplySSL res = new ResComodoAutoApplySSL();

            NameValueCollection resp = ComodoSendCommand("https://secure.comodo.net/products/!AutoApplySSL", req);

            foreach (rfl.PropertyInfo pi in res.GetType().GetProperties())
            {
                pi.SetValue(res, resp.Get(pi.Name));
            }

            if (Convert.ToInt32(resp.Get("errorCode")) < 0)
            {
                throw GetComodoErrorException(resp.Get("errorCode"), resp.Get("errorMessage"), "", "AutoApplySSL");
            }

            return res;
        }

        /// <summary>
        /// Satın alınmış SSL sertifikasını değiştir (Re-Generate)
        /// </summary>
        private ResComodoAutoReplaceSSL ComodoAutoReplaceSSL(ReqComodoAutoReplaceSSL req)
        {
            ResComodoAutoReplaceSSL res = new ResComodoAutoReplaceSSL();

            NameValueCollection resp = ComodoSendCommand("https://secure.comodo.net/products/!AutoReplaceSSL", req);

            foreach (rfl.PropertyInfo pi in res.GetType().GetProperties())
            {
                pi.SetValue(res, resp.Get(pi.Name));
            }

            if (Convert.ToInt32(resp.Get("errorCode")) < 0)
            {
                throw GetComodoErrorException(resp.Get("errorCode"), resp.Get("errorMessage"), "", "AutoReplaceSSL");
            }

            return res;
        }

        /// <summary>
        /// Sertifikayı iptal eder, bu method işlendiğinde comodo bakiye iadesi yapmaz
        /// </summary>
        private ResComodoAutoRevokeSSL ComodoAutoRevokeSSL(ReqComodoAutoRevokeSSL req)
        {
            ResComodoAutoRevokeSSL res = new ResComodoAutoRevokeSSL();

            NameValueCollection resp = ComodoSendCommand("https://secure.comodo.net/products/!AutoRevokeSSL", req);

            foreach (rfl.PropertyInfo pi in res.GetType().GetProperties())
            {
                pi.SetValue(res, resp.Get(pi.Name));
            }

            if (Convert.ToInt32(resp.Get("errorCode")) < 0)
            {
                throw GetComodoErrorException(resp.Get("errorCode"), resp.Get("errorMessage"), "", "AutoRevokeSSL");
            }

            return res;
        }

        /// <summary>
        /// DCV Doğrulama yöntemini veya doğrulama adresini değiştir (MAIL/HTTP/HTTPS/CNAME)
        /// </summary>
        private ResUpdateDCV ComodoAutoUpdateDCV(ReqUpdateDCV req)
        {
            ResUpdateDCV res = new ResUpdateDCV();

            NameValueCollection resp = ComodoSendCommand("https://secure.comodo.net/products/!AutoUpdateDCV", req);

            foreach (rfl.PropertyInfo pi in res.GetType().GetProperties())
            {
                pi.SetValue(res, resp.Get(pi.Name));
            }

            if (Convert.ToInt32(resp.Get("errorCode")) < 0)
            {
                throw GetComodoErrorException(resp.Get("errorCode"), resp.Get("errorMessage"), "", "AutoUpdateDCV");
            }

            return res;
        }

        /// <summary>
        /// SSL sertifikasını ve bilgilerini geri döndürür
        /// </summary>
        private ResCollectSSL ComodoCollectSSL(ReqCollectSSL req)
        {
            ResCollectSSL res = new ResCollectSSL();

            NameValueCollection resp = ComodoSendCommand("https://secure.comodo.net/products/download/CollectSSL", req);

            foreach (rfl.PropertyInfo pi in res.GetType().GetProperties())
            {
                pi.SetValue(res, resp.Get(pi.Name));
            }

            if (Convert.ToInt32(resp.Get("errorCode")) < 0)
            {
                throw GetComodoErrorException(resp.Get("errorCode"), resp.Get("errorMessage"), "", "CollectSSL");
            }

            return res;
        }

        /// <summary>
        /// CSR kodunu çözümler ve bilgileri okumamızı sağlar
        /// </summary>
        private ResDecodeCSR ComodoDecodeCSR(ReqDecodeCSR req)
        {
            ResDecodeCSR res = new ResDecodeCSR();

            NameValueCollection resp = ComodoSendCommand("https://secure.comodo.net/products/!DecodeCSR", req);

            foreach (rfl.PropertyInfo pi in res.GetType().GetProperties())
            {
                pi.SetValue(res, resp.Get(pi.Name));
            }

            if (Convert.ToInt32(resp.Get("errorCode")) < 0)
            {
                throw GetComodoErrorException(resp.Get("errorCode"), resp.Get("errorMessage"), "", "DecodeCSR");
            }

            return res;
        }

        /// <summary>
        /// DCV ile doğrulama yapmak için eposta adreslerini getirir
        /// </summary>
        private IEnumerable<string> ComodoGetDcvEmailAddressList(string domainName)
        {
            string response = Provider.RequestExternalWebAPI("https://secure.comodo.net/products/!GetDCVEmailAddressList", string.Format("loginName={0}&loginPassword={1}&domainName={2}", _comodoUsername, HttpUtility.UrlEncode(_comodoPassword), HttpUtility.UrlEncode(domainName)), true);

            string[] lines = response.Trim().Split('\n');
            string mails = string.Empty;


            if (lines.Length > 0)
            {
                if ("0".Equals(lines[0]))
                {
                    for (int i = 2; i < lines.Length; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(lines[i]) && lines[i].Contains('\t'))
                        {
                            mails += lines[i].Split('\t')[1] + " ";
                        }
                    }
                }
                else
                {
                    throw GetComodoErrorException(lines[0], lines[1], "", "GetDcvEmailAddressList");
                }
            }
            else
            {
                throw GetComodoErrorException("null", "Comododan cevap gelmedi", "", "GetDcvEmailAddressList");
            }

            return mails.Trim().Split(' ');
        }

        /// <summary>
        /// Comodoya veri gönderir ve yanıt alır (Sender)
        /// </summary>
        private NameValueCollection ComodoSendCommand(string url, object request)
        {
            // Request object to string (&name=value)
            string parameters = request
                .GetType()
                .GetProperties()
                .Select(pi => pi.Name + "=" + HttpUtility.UrlEncode(pi.PropertyType.IsEnum && !Attribute.IsDefined(pi.PropertyType, typeof(StringAttr)) ? ((int)pi.GetValue(request, null)).ToString() : (pi.GetValue(request, null) ?? "").ToString()))
                .Aggregate((current, next) => (current ?? "") + "&" + (next ?? ""));

            string responseFormat = !url.Contains("!AutoUpdateDCV") && !url.Contains("DecodeCSR") ? "&responseFormat=1" : string.Empty;
            string collectSSLArguments = url.Contains("CollectSSL") ? "&queryType=1&showValidityPeriod=Y&showFQDN=Y&showExtStatus=Y&showStatusDetails=Y" : string.Empty;
            string decodeCsrArguments = url.Contains("DecodeCSR") ? "&responseFormat=0&showErrorCodes=Y&showErrorMessages=Y&showFieldNames=Y&showEmptyFields=Y&showCN=Y&showAddress=Y&showPublicKey=Y&showKeySize=Y&showSANDNSNames=N&showCSR=Y&showCSRHashes=Y&showSignatureAlgorithm=Y&countryNameType=TWOCHAR" : string.Empty;

            string requestString = string.Format("loginName={0}&loginPassword={1}&{2}{3}{4}{5}", HttpUtility.UrlEncode(_comodoUsername), HttpUtility.UrlEncode(_comodoPassword), parameters, responseFormat, collectSSLArguments, decodeCsrArguments);

            string response = Provider.RequestExternalWebAPI(url, requestString, true);

            // Bazı api fonksiyonları düzenli formatla değil, satır satır bilgi gönderiyor. Onları işlemek için aşağıdaki kodları kullanıyorum #YalcinG
            if (requestString.Contains("responseFormat=0"))
            {
                if (url.Contains("DecodeCSR"))
                {
                    response = response.Replace("Public Key", "PublicKey").Replace("Key Size", "KeySize");
                }

                var responses = response.Split('\n');

                if (responses[0] != "0")
                {
                    response = "errorCode=" + responses[1].Split(' ')[0] + "&errorMessage=" + responses[1].Remove(0, responses[1].Split(' ')[0].Length);
                }
                else
                {
                    response = "errorCode=0&errorMessage=";
                }

                for (int i = Convert.ToInt32(responses[0]); i < responses.Length; i++)
                {
                    response += "&" + responses[i].Trim();
                }
            }

            return HttpUtility.ParseQueryString(response);
        }

        /// <summary>
        /// DCV domain doğrulama mailini yeniden gönderir
        /// </summary>
        private ResComodoResendDCVEmail ComodoResendDCVEmail(ReqComodoResendDCVEmail req)
        {
            return new ResComodoResendDCVEmail();
        }

        /// <summary>
        /// Verilen domainde ssl olup olmadığı kontrol edilir
        /// </summary>
        private ResSSLChecker ComodoSSLCheckDomain(string domainName)
        {
            const string apiUrl = "http://secure.comodo.com/sslchecker";

            string response = Provider.RequestExternalWebAPI(apiUrl, string.Format("url={0}&response_format=0&caller_name=isimtescil", HttpUtility.UrlEncode(domainName)), true);

            var postParams = HttpUtility.ParseQueryString(response);

            ResSSLChecker res = new ResSSLChecker { cert = new ResSSLChecker.Cert() };

            if (Convert.ToInt32(postParams.Get("error_code")) < 0)
            {
                throw GetComodoErrorException(postParams.Get("error_code"), postParams.Get("error_message"), response, "SSLChecker");
            }

            foreach (rfl.PropertyInfo pi in res.cert.GetType().GetProperties().Where(pi => postParams.Get("cert_" + pi.Name) != null))
            {
                pi.SetValue(res.cert, postParams.Get("cert_" + pi.Name));
            }

            res.chain = new ResSSLChecker.Chain();

            foreach (rfl.PropertyInfo pi in res.chain.GetType().GetProperties().Where(pi => postParams.Get("chain_" + pi.Name) != null))
            {
                pi.SetValue(res.chain, postParams.Get("chain_" + pi.Name));
            }

            res.next_issuer = new ResSSLChecker.NextIssuer();

            foreach (rfl.PropertyInfo pi in res.next_issuer.GetType().GetProperties().Where(pi => postParams.Get("next_issuer_" + pi.Name) != null))
            {
                pi.SetValue(res.next_issuer, postParams.Get("next_issuer_" + pi.Name));
            }

            res.server = new ResSSLChecker.Server();

            foreach (rfl.PropertyInfo pi in res.server.GetType().GetProperties().Where(pi => postParams.Get("server_" + pi.Name) != null))
            {
                pi.SetValue(res.server, postParams.Get("server_" + pi.Name));
            }

            return res;
        }

        /// <summary>
        /// Comodo'dan dönen hataları APIExpection nesnesine çevirir
        /// </summary>
        private APIException GetComodoErrorException(string code, string message, string data, string process)
        {
            ErrorCodes errorCode = ErrorCodes.Undefined;

            switch (process)
            {
                case "AutoApplySSL":
                    switch (code)
                    {
                        case "-1": errorCode = ErrorCodes.RequestWasNotMadeOverHttps; break;
                        case "-2": errorCode = ErrorCodes.XIsAnUnrecognisedArgument; break;
                        case "-3": errorCode = ErrorCodes.TheArgumentIsMissing; break;
                        case "-4": errorCode = ErrorCodes.TheValueOfTheXArgumentIsInvalid; break;
                        case "-5": errorCode = ErrorCodes.TheCsrCommonNameMayNotContainAWildcard; break;
                        case "-6": errorCode = ErrorCodes.TheCsrCommonNameMustContainOneWildcard; break;
                        case "-7": errorCode = ErrorCodes.XIsNotAValidISO3166CountryCode; break;
                        case "-8": errorCode = ErrorCodes.TheCsrIsMissingARequiredField; break;
                        case "-9": errorCode = ErrorCodes.TheCsrIsNotValidBase64Data; break;
                        case "-10": errorCode = ErrorCodes.TheCsrCannotBeDecoded; break;
                        case "-11": errorCode = ErrorCodes.TheCsrUsesAnUnsupportedAlgorithm; break;
                        case "-12": errorCode = ErrorCodes.TheCsrHasAnInvalidSignature; break;
                        case "-13": errorCode = ErrorCodes.TheCsrUsesAnUnsupportedKeySize; break;
                        case "-14": errorCode = ErrorCodes.AnUnknownErrorOccurred; break;
                        case "-15": errorCode = ErrorCodes.NotEnoughCredit; break;
                        case "-16": errorCode = ErrorCodes.PermissionDenied; break;
                        case "-17": errorCode = ErrorCodes.RequestUsedGetRatherThanPost; break;
                        case "-18": errorCode = ErrorCodes.TheCsrCommonNameMayNotBeAFullyQualifiedDomainName; break;
                        case "-19": errorCode = ErrorCodes.TheCsrCommonNameMayNotBeAnInternetAccessibleIpAddress; break;
                        case "-35": errorCode = ErrorCodes.TheCsrCommonNameMayNotBeAnIpAddress; break;
                        case "-40": errorCode = ErrorCodes.TheCsrUsesAKeyThatIsBelievedToHaveBeenCompromised; break;
                    }
                    break;
                case "AutoReplaceSSL":
                    switch (code)
                    {
                        case "-1": errorCode = ErrorCodes.RequestWasNotMadeOverHttps; break;
                        case "-2": errorCode = ErrorCodes.UnrecognisedArgument; break;
                        case "-3": errorCode = ErrorCodes.TheArgumentIsMissing; break;
                        case "-4": errorCode = ErrorCodes.TheValueOfTheXArgumentIsInvalid; break;
                        case "-5": errorCode = ErrorCodes.TheCsrCommonNameMayNotContainAWildcard; break;
                        case "-6": errorCode = ErrorCodes.TheCsrCommonNameMustContainOneWildcard; break;
                        case "-7": errorCode = ErrorCodes.XIsNotAValidISO3166CountryCode; break;
                        case "-8": errorCode = ErrorCodes.TheCsrIsMissingARequiredField; break;
                        case "-9": errorCode = ErrorCodes.TheCsrIsNotValidBase64Data; break;
                        case "-10": errorCode = ErrorCodes.TheCsrCannotBeDecoded; break;
                        case "-11": errorCode = ErrorCodes.TheCsrUsesAnUnsupportedAlgorithm; break;
                        case "-12": errorCode = ErrorCodes.TheCsrHasAnInvalidSignature; break;
                        case "-13": errorCode = ErrorCodes.TheCsrUsesAnUnsupportedKeySize; break;
                        case "-14": errorCode = ErrorCodes.AnUnknownErrorOccurred; break;
                        case "-15": errorCode = ErrorCodes.NotEnoughCredit; break;
                        case "-16": errorCode = ErrorCodes.PermissionDenied; break;
                        case "-17": errorCode = ErrorCodes.RequestUsedGetRatherThanPost; break;
                        case "-18": errorCode = ErrorCodes.TheCsrCommonNameMayNotBeAFullyQualifiedDomainName; break;
                        case "-19": errorCode = ErrorCodes.TheCsrCommonNameMayNotBeAnInternetAccessibleIpAddress; break;
                        case "-26": errorCode = ErrorCodes.TheCertificateIsCurrentlyBeingIssued; break;
                        case "-36": errorCode = ErrorCodes.TheCertificateHasAlreadyExpired; break;
                        case "-40": errorCode = ErrorCodes.TheCsrUsesAKeyThatIsBelievedToHaveBeenCompromised; break;
                    }
                    break;
                case "AutoRevokeSSL":
                    switch (code)
                    {
                        case "-1": errorCode = ErrorCodes.RequestWasNotMadeOverHttps; break;
                        case "-2": errorCode = ErrorCodes.UnrecognisedArgument; break;
                        case "-3": errorCode = ErrorCodes.TheArgumentIsMissing; break;
                        case "-4": errorCode = ErrorCodes.TheValueOfTheXArgumentIsInvalid; break;
                        case "-14": errorCode = ErrorCodes.AnUnknownErrorOccurred; break;
                        case "-16": errorCode = ErrorCodes.PermissionDenied; break;
                        case "-17": errorCode = ErrorCodes.RequestUsedGetRatherThanPost; break;
                        case "-20": errorCode = ErrorCodes.TheCertificateRequestHasAlreadyBeenRejected; break;
                        case "-21": errorCode = ErrorCodes.TheCertificateHasAlreadyBeenRevoked; break;
                        case "-26": errorCode = ErrorCodes.TheCertificateIsCurrentlyBeingIssued; break;
                    }
                    break;
                case "AutoUpdateDCV":
                    switch (code)
                    {
                        case "-1": errorCode = ErrorCodes.RequestWasNotMadeOverHttps; break;
                        case "-2": errorCode = ErrorCodes.UnrecognisedArgument; break;
                        case "-3": errorCode = ErrorCodes.TheArgumentIsMissing; break;
                        case "-4": errorCode = ErrorCodes.TheValueOfTheXArgumentIsInvalid; break;
                        case "-14": errorCode = ErrorCodes.AnUnknownErrorOccurred; break;
                        case "-16": errorCode = ErrorCodes.PermissionDenied; break;
                        case "-17": errorCode = ErrorCodes.RequestUsedGetRatherThanPost; break;
                    }
                    break;
                case "CollectSSL":
                    switch (code)
                    {
                        case "-1": errorCode = ErrorCodes.RequestWasNotMadeOverHttps; break;
                        case "-2": errorCode = ErrorCodes.UnrecognisedArgument; break;
                        case "-3": errorCode = ErrorCodes.TheArgumentIsMissing; break;
                        case "-4": errorCode = ErrorCodes.TheValueOfTheXArgumentIsInvalid; break;
                        case "-14": errorCode = ErrorCodes.AnUnknownErrorOccurred; break;
                        case "-16": errorCode = ErrorCodes.PermissionDenied; break;
                        case "-17": errorCode = ErrorCodes.RequestUsedGetRatherThanPost; break;
                        case "-20": errorCode = ErrorCodes.TheCertificateRequestHasBeenRejected; break;
                        case "-21": errorCode = ErrorCodes.TheCertificateHasBeenRevoked; break;
                        case "-22": errorCode = ErrorCodes.StillAwaitingPayment; break;
                    }
                    break;
                case "DecodeCSR":
                    switch (code)
                    {
                        case "-1": errorCode = ErrorCodes.RequestWasNotMadeOverHttpsAndShowCsrHashesYWasSpecified; break;
                        case "-2": errorCode = ErrorCodes.UnrecognisedArgument; break;
                        case "-3": errorCode = ErrorCodes.TheArgumentIsMissing; break;
                        case "-4": errorCode = ErrorCodes.TheValueOfTheXArgumentIsInvalid; break;
                        case "-5": errorCode = ErrorCodes.TheCommonNameMayNotContainA; break;
                        case "-6": errorCode = ErrorCodes.TheCommonNameMustContainOne; break;
                        case "-7": errorCode = ErrorCodes.XIsNotAValidISO3166CountryCode; break;
                        case "-8": errorCode = ErrorCodes.TheCsrIsMissingARequiredField; break;
                        case "-10": errorCode = ErrorCodes.TheCsrCannotBeDecoded; break;
                        case "-11": errorCode = ErrorCodes.TheCsrUsesAnUnsupportedAlgorithm; break;
                        case "-12": errorCode = ErrorCodes.TheCsrHasAnInvalidSignature; break;
                        case "-13": errorCode = ErrorCodes.TheCsrUsesAnUnsupportedKeySize; break;
                        case "-14": errorCode = ErrorCodes.AnUnknownErrorOccurred; break;
                        case "-18": errorCode = ErrorCodes.TheCommonNameMayNotBeAFullyQualifiedDomainName; break;
                        case "-19": errorCode = ErrorCodes.TheCommonNameMayBeAnInternetAccessibleIpAddress; break;
                        case "-23": errorCode = ErrorCodes.TheCommonNameShouldNotIncludeTheHttpPart; break;
                        case "-24": errorCode = ErrorCodes.TheCommonNameShouldNotIncludeTheHttpsPart; break;
                        case "-25": errorCode = ErrorCodes.TheCommonNameMayOnlyContainTheFollowingCharactersAZaz09; break;
                        case "-40": errorCode = ErrorCodes.TheCsrUsesAKeyThatIsBelievedToHaveBeenCompromised; break;
                        case "-41": errorCode = ErrorCodes.TheCsrUsesAnInvalidKey; break;
                    }
                    break;
                case "GetDcvEmailAddressList":
                    switch (code)
                    {
                        case "-1": errorCode = ErrorCodes.RequestWasNotMadeOverHttps; break;
                        case "-2": errorCode = ErrorCodes.UnrecognisedArgument; break;
                        case "-3": errorCode = ErrorCodes.TheArgumentIsMissing; break;
                        case "-4": errorCode = ErrorCodes.TheValueOfTheXArgumentIsInvalid; break;
                        case "-14": errorCode = ErrorCodes.AnUnknownErrorOccurred; break;
                        case "-16": errorCode = ErrorCodes.PermissionDenied; break;
                        case "-17": errorCode = ErrorCodes.RequestUsedGetRatherThanPost; break;
                        case "-19": errorCode = ErrorCodes.TheDomainNameMayNotBeAnInternetAccessibleIpAddress; break;
                        case "-37": errorCode = ErrorCodes.TheDomainNameIsAnInternetServerNameOrInternetIpAddress; break;
                    }
                    break;
                case "SSLChecker":
                    switch (code)
                    {
                        case "-1": errorCode = ErrorCodes.ChunkedEncodingIsUnsupported; break;
                        case "-2": errorCode = ErrorCodes.UnknownContentType; break;
                        case "-3": errorCode = ErrorCodes.UnsupportedContentType; break;
                        case "-4": errorCode = ErrorCodes.DomainNotFound; break;
                        case "-5": errorCode = ErrorCodes.InvalidProtocolOrPort; break;
                        case "-6": errorCode = ErrorCodes.DomainHasNoAddress; break;
                        case "-7": errorCode = ErrorCodes.PermanentNameserverError; break;
                        case "-8": errorCode = ErrorCodes.TemporaryNameserverError; break;
                        case "-9": errorCode = ErrorCodes.UnexpectedError; break;
                        case "-10": errorCode = ErrorCodes.TimedOutWhileAttemptingToConnect; break;
                        case "-11": errorCode = ErrorCodes.InvalidDomainOrUrl; break;
                        case "-12": errorCode = ErrorCodes.UnableToEstablishAnSSLConnection; break;
                        case "-13": errorCode = ErrorCodes.NoSiteCertificateWasReturned; break;
                        case "-14": errorCode = ErrorCodes.ThisProtocolDoesNotUseSSLOrTLS; break;
                        case "-15": errorCode = ErrorCodes.PermissionDenied; break;
                    }
                    break;
            }

            return new APIException(message + " ?" + data, errorCode);
        }
        #endregion

        /// <summary>
        /// OpenSSL.exe 'yi çalıştıran ve çıktısını alan method
        /// </summary>
        /// <param name="cmd">Başına openssl veya openssl.exe koymadan direkt parametreleri yazıyoruz</param>
        private string ExecuteOpenSSL(string cmd)
        {
            // OpenSSL çalışma komutları
            ProcessStartInfo startInfo = new ProcessStartInfo(ConfigurationManager.AppSettings["opensslExePath"])
            {
                UseShellExecute = false,
                Verb = "runas",
                Arguments = cmd,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            string processOutput, processError;
            using (Process process = new Process { StartInfo = startInfo })
            {
                process.Start();
                processOutput = process.StandardOutput.ReadToEnd().Trim();
                processError = process.StandardError.ReadToEnd().Trim();
            }

            if (!string.IsNullOrWhiteSpace(processError))
            {
                throw new Exception(processError);
            }

            return processOutput;
        }
    }
}