using DealerSafe2.DTO.Enums;
using DealerSafe2.DTO.Request;

namespace DealerSafe2.DTO.EntityInfo
{
    public class DashboardItem : BaseRequest
    {
        public DashboardItem()
        {
            Type = "Link";
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }
        public string LinkText { get; set; }
    }
}
