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

    public enum DMItemStates
    {
        None,
        OnAuction,
        NotOnAuction,
        OfferAccepted
    }

    public enum DMAuctionStates
    {
        Open,
        Completed,
        DirectBuy,
        Suspended,
        Cancelled,
        DueDateReached
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
        BeingEdited,
        Processed
    }

    public enum DMBrokerageStates
    {
        Open,
        BeingEdited,
        Processed
    }
}
