using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Xml;
using DealerSafe2.API.Entity.Common;
using DealerSafe2.API.Entity.Crm;
using DealerSafe2.API.Entity.Jobs;
using DealerSafe2.API.Entity.Members;
using DealerSafe2.API.Workers;
using DealerSafe2.DTO;
using DealerSafe2.DTO.EntityInfo;
using DealerSafe2.DTO.Enums;
using DealerSafe2.DTO.Request;
using DealerSafe2.DTO.Response;
using DealerSafe2.API.Api.Library;
using System.Configuration;

namespace DealerSafe2.API
{
    public partial class ApiJson
    {
        #region Common

        public List<IdName> GetEnumList(string enumName)
        {
            var enumType = typeof(MemberTypes).Assembly.GetType("DealerSafe2.DTO.Enums." + enumName);
            if (enumType == null)
                throw new APIException("Enum not found. Did you put it in enums folder?");

            return
                Enum.GetNames(enumType)
                    .Select(id => new IdName() { Id = id, Name = id.PascalCaseWords().StringJoin(" ") })
                    .OrderBy(o => o.Name)
                    .ToList();
        }

        public bool ExecuteJob(string jobId)
        {
            var job = Provider.Database.Read<Job>("Id = {0}", jobId);
            if (job == null)
                throw new APIException("Job not found: " + jobId);
            try
            {
                var worker = BaseWorker.GetWorker(job.Command);
                if (worker == null)
                    throw new APIException("Worker not defined for " + job.Command);

                worker.ExecuteInternal(job);
            }
            catch (Exception ex)
            {
                job.State = JobStates.TryAgain;
                job.Save();

                JobData jd = Provider.Database.Read<JobData>("JobId={0}", job.Id);
                if (jd == null) jd = new JobData() { JobId = job.Id };
                jd.Request = jd.Request ?? "";
                jd.Response = ex.Message;
                jd.Save();
            }

            return true;
        }

        public ExchangeRates GetExchangeRates(ReqEmpty req)
        {
            ExchangeRates rates = HttpContext.Current.Application["exchangeRates"] as ExchangeRates;

            if (rates == null || rates.Date < Provider.Database.Now.Date)
            {
                rates = new ExchangeRates { Date = Provider.Database.Now.Date };

                List<ExchangeRate> list =
                    Provider.Database.ReadList<ExchangeRate>("select * from ExchangeRate where InsertDate>={0}",
                                                             Provider.Database.Now.Date);
                if (list == null || list.Count == 0)
                {
                    XmlTextReader rdr = new XmlTextReader("http://www.tcmb.gov.tr/kurlar/today.xml");
                    DataSet ds = new DataSet();
                    ds.ReadXml(rdr);

                    foreach (DataRow dr in ds.Tables["Currency"].Rows)
                    {
                        try
                        {
                            ExchangeRate rate = new ExchangeRate
                                {
                                    Currency =
                                        (dr["CurrencyCode"].ToString() == "USD")
                                            ? "$"
                                            : (dr["CurrencyCode"].ToString() == "EUR" ? "€" : dr["CurrencyCode"].ToString()),
                                    PriceTL =
                                        Convert.ToInt32(
                                            decimal.Parse(dr["ForexSelling"].ToString(), CultureInfo.InvariantCulture) *
                                            1000000 / int.Parse(dr["Unit"].ToString()))
                                };
                            rate.Save();

                            rates.Add(rate.ToEntityInfo<ExchangeRateInfo>());
                        }
                        catch { }
                    }

                    HttpContext.Current.Application["exchangeRates"] = rates;
                }
                else
                {
                    rates.Date = Provider.Database.Now.Date;
                    rates.AddRange(list.ToEntityInfo<ExchangeRateInfo>());
                    HttpContext.Current.Application["exchangeRates"] = rates;
                }
            }

            return rates;
        }

        public bool SendMessage(ReqSendMessage req)
        {
            Job j = new Job();
            j.Command = JobCommands.CCSendMessage;
            j.Executer = JobExecuters.Machine;
            j.Name = "to " + (req.Email.IsEmpty() ? "member " + req.MemberId : req.Email);
            j.RelatedEntityName = "CCMessageTemplate";
            j.RelatedEntityId = req.TemplateId;
            j.StartDate = req.SendDate;
            j.Save();

            JobData jd = new JobData();
            jd.Request = req.ToJSON();
            jd.JobId = j.Id;
            jd.Response = "";
            jd.Save();

            return true;
        }

        #endregion


        internal string GetNextIdleStaffMemberId(Departments department)
        {
            var staffMembers =
                Provider.Database.ReadList<Member>(
                    "SELECT * FROM Member WHERE IsStaffMember = 1 AND IsDeleted = 0 ORDER BY Id");
            if (HttpContext.Current.Application["lastIdleStaffMemberId"] == null)
            {
                var m = staffMembers.FirstOrDefault(sm => sm.StaffDepartment == department);
                if (m == null)
                {
                    HttpContext.Current.Application["lastIdleStaffMemberId"] = staffMembers[0].Id;
                    return staffMembers[0].Id;
                }

                HttpContext.Current.Application["lastIdleStaffMemberId"] = m.Id;
                return m.Id;
            }

            var staffMembersDep = staffMembers.Where(sm => sm.StaffDepartment == department).ToList();

            if (staffMembersDep.Count == 0)
            {
                var currIndex =
                    staffMembers.IndexOf(
                        m => m.Id == HttpContext.Current.Application["lastIdleStaffMemberId"].ToString());
                if (currIndex == staffMembers.Count - 1)
                    currIndex = 0;
                else
                    currIndex++;

                HttpContext.Current.Application["lastIdleStaffMemberId"] = staffMembers[currIndex].Id;

                return staffMembers[currIndex].Id;
            }

            var currIndexD =
                staffMembersDep.IndexOf(m => m.Id == HttpContext.Current.Application["lastIdleStaffMemberId"].ToString());
            if (currIndexD == staffMembersDep.Count - 1)
                currIndexD = 0;
            else
                currIndexD++;

            HttpContext.Current.Application["lastIdleStaffMemberId"] = staffMembersDep[currIndexD].Id;

            return staffMembersDep[currIndexD].Id;
        }

    }


}