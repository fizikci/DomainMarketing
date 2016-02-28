using System;
using System.Collections.Generic;
namespace DealerSafe.DTO.Membership
{
    [Serializable]
    public class MemberInfo
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string NameSurname { get; set; }
        public string CompanyName { get; set; }
        public GenderType Gender { get; set; }
        public string WWW { get; set; }
        public string Phone2CC { get; set; }
        public string Phone2 { get; set; }
        public string Country { get; set; }
        public bool RecStatus { get; set; }
        public string RecCreateDate { get; set; }
        public MemberTypeList MemberType { get; set; }
        public string Username { get; set; }
        public bool PollRequest { get; set; }
        public int AddressContactId { get; set; }
        public int AddressInvoiceId { get; set; }
        public float Debt { get; set; }
        public float Credit { get; set; }
        public int Level { get; set; }
        public int Status { get; set; }
        public int Approved { get; set; }
        public int GSMApproved { get; set; }
        public int IsCreditCardMultiUse { get; set; }
        public int IsMemberSmsSend { get; set; }
        public string StrSmsEuId { get; set; }
        public bool ThreeDSecureNecessity { get; set; }
        public EducationType Education { get; set; }
        public string BirthDate { get; set; }
        public int InvoiceCompanyID { get; set; }
        public bool InvoiceSetup { get; set; }
        public bool InvoiceSend { get; set; }
        public int KayakoUserID { get; set; }
        public string ImageGuid { get; set; }
        public bool IsPartner { get; set; }
        public SuggestionType Suggestion { get; set; }
        public int ViewLoginCampaign { get; set; }
        public string ActivationCode { get; set; }
        public string Password { get; set; }
        public string TCKimlikNo { get; set; }

        public string TC
        {
            get
            {
                return string.IsNullOrWhiteSpace(TCKimlikNo) ? "" : new Security().Decrypt(TCKimlikNo).Replace("isimtescilkey", "");
            }
        }

        public bool TCIsEmpty
        {
            get { return TC.Length == 0;}
        }
        
        public enum GenderType
        {
            None = 0,
            Male = 1,
            Female = 2
        }
    }
}