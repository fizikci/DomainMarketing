using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Membership
{
    public class MemberMessagesInfo
    {
        public bool Process { get; set; }
        public List<MessageDetail> MessageList { get; set; }

        public class MessageDetail
        {
            public int Id { get; set; }
            public string CreatedDate { get; set; }
            public int ReceiverMemberId { get; set; }
            public int SenderMemberId { get; set; }
            public bool MessageRead { get; set; }
            public string Subject { get; set; }
            public string Message { get; set; }
            public bool MessageStatus { get; set; }
        }
    }
}
