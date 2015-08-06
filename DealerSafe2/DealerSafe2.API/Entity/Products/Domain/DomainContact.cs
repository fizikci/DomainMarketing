using Cinar.Database;
using DealerSafe.DTO.Epp.Request;
using DealerSafe2.DTO.Enums;
using Epp.Protocol.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.Products.Domain
{
    public class DomainContact : NamedEntity
    {
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

        public ReqContactCreate ConvertToReqContactCreate()
        {
            var res = new ReqContactCreate();

            res.ContactId = this.Id;
            res.Email = this.Email;
            res.Fax = this.Fax;
            res.Postals = new List<PostalInfo>() 
            { 
                new PostalInfo {
                    Address = new AddressInfo{
                        City = this.City,
                        CountryCode = this.Country,
                        PostalCode = this.Zip,
                        SP = this.State,
                        Streets = new List<string>{this.Address}
                    }
            }};
            if (!this.Phone.IsEmpty())
                res.Voice = new VoiceInfo
                {
                    Voice = this.Phone
                };

            return res;
        }
    }

}