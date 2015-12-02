using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.Enums
{
    public enum DMItemTypes
    {
        Domain,
        WebProject
    }

    public enum DMAuctionStates
    {
        NotOnAuction,
        Open,
        Completed,
        Suspended,
        Cancelled
        //DirectBuy,
        //DueDateReached
    }

    public enum DMOfferStatus
    {
        None,
        Accepted,
        Rejected
    }

    public enum DMMedals
    {
        New,
        Bronze,
        Silver,
        Gold,
        Platinium
    }

    public enum DMSaleStates
    {
        None,
        WaitingForPayment,
        WaitingForTransfer,
        SuccessfullyClosed,
        CancelledBySeller,
        CancelledByBuyer,
        TimeoutForPayment
    }

    public enum DMExpertiseStates
    {
        Open,
        Processing,
        Processed
    }

    public enum DMBrokerageStates
    {
        Open,
        Processing,
        Processed
    }
}
