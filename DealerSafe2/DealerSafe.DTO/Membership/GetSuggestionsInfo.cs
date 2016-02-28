using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Membership
{
    public class GetSuggestionsInfo
    {
        public List<SuggestionDetail> Suggestions { get; set; }
    }
    public class SuggestionDetail
    {
        public int Id { get; set; }
        public string RecCreatedDate { get; set; }
        public string SuggestionOption { get; set; }
    }
}
