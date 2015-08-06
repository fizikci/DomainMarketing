using Cinar.Database;
namespace DealerSafe2.API.Entity.Jobs
{
    public class BaseJobDetail : BaseEntity
    {
        [ColumnDetail(Length = 12)]
        public string JobId { get; set; }

        public Job Job() { return Provider.ReadEntityWithRequestCache<Job>(JobId); }
    }
}