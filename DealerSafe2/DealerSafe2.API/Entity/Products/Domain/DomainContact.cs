using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cinar.Database;
using DealerSafe.DTO.Epp.Request;
using DealerSafe2.DTO.Enums;
using Epp.Protocol.Contacts;
using Epp.Protocol.Shared;

namespace DealerSafe2.API.Entity.Products.Domain
{
    public class DomainContact : NamedEntity
    {
        [ColumnDetail(Length = 12)]
        public string MemberId { get; set; }

        public string Surname { get; set; }

        public string Organization { get; set; }

        public string Email { get; set; }
        
        [ColumnDetail(Length = 20)]
        public string Phone { get; set; }
        
        [ColumnDetail(Length = 20)]
        public string Fax { get; set; }

        [ColumnDetail(Length = 10)]
        public string Zip { get; set; }
        
        public string Address { get; set; }

        [ColumnDetail(Length = 50)]
        public string Country { get; set; }

        [ColumnDetail(Length = 50)]
        public string State { get; set; }

        [ColumnDetail(Length = 50)]
        public string City { get; set; }

        [ColumnDetail(Length = 50)]
        public string Town { get; set; }

        [ColumnDetail(Length = 50)]
        public string AuthInfo { get; set; }

        public DomainContact() {
            this.AuthInfo = Utility.CreatePassword(5) + "!1Fbs";
        }

        public ReqContactCreate ConvertToReqContactCreate(string domainName)
        {
            var req = new ReqContactCreate();

            req.DomainName = domainName;
            
            req.ContactId = this.Id;
            req.Email = this.Email;
            if(!req.Fax.IsEmpty()) req.Fax = "+90." + this.Fax.Replace("+90","");
            req.Postals = new List<PostalInfo>() 
            { 
                new PostalInfo {
                    Type = PostalInfo.PostalType.Int,
                    Name = this.Name + " " + this.Surname,
                    Organization = this.Organization,
                    Address = new AddressInfo{
                        City = this.City,
                        CountryCode = this.Country,
                        PostalCode = this.Zip,
                        SP = this.State,
                        Streets = new List<string>{this.Address}
                    }
            }};
            if (!this.Phone.IsEmpty())
                req.Voice = new VoiceInfo
                {
                    Voice = "+90." + this.Phone.Replace("+90","")
                };

            req.AuthInfo = new AuthInfo()
                            {
                                Password = this.AuthInfo
                            };

            return req;
        }
    }

}