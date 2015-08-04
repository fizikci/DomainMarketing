using Cinar.Database;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.API.Entity.Crm
{
    public class Feedback : NamedEntity
    {
        [ColumnDetail(ColumnType = DbType.VarChar, Length = 100)]
        public string Email { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 100)]
        public string Subject { get; set; }

        [ColumnDetail(ColumnType = DbType.Text)]
        public string Message { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 20)]
        public Departments Department { get; set; }

        public string ReplyMessage { get; set; }

    }

    public class ViewFeedback : Feedback
    {
        public string JobId { get; set; }
        public JobStates State { get; set; }
        public string ExecuterId { get; set; }
    }
}