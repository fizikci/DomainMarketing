using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.Request
{
    public class ReqAcceptOffer
    {
        public string MemberId { get; set; }
        public string OffererMemberId {get;set;}
        public int OfferValue { get; set;}
        public string DMItemId{ get; set;}
        public string DMOfferId { get; set; }
    }
}

