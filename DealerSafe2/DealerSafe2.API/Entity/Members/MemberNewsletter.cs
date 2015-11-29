using System;
using Cinar.Database;

namespace DealerSafe2.API.Entity.Members
{
    public class MemberNewsletter : BaseEntity
    {
        [ColumnDetail(Length = 12)]
        public string NewsletterDefinitionId { get; set; }
        [ColumnDetail(Length = 12)]
        public string MemberId { get; set; }

        public NewsletterDefinition NewsletterDefinition() { return Provider.ReadEntityWithRequestCache<NewsletterDefinition>(NewsletterDefinitionId); }
        public Member Member() { return Provider.ReadEntityWithRequestCache<Member>(MemberId); }

    }


    public class ListViewMemberNewsletter : MemberNewsletter
    {
        public string NewsletterDefinitionName { get; set; }
    }

}