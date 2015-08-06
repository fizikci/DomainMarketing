using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerSafe2.DTO.Enums
{
    public enum ProfileType
    {
        Email = 1,
        Sms = 2
    }
    public enum Priority
    {
        Low = 1,
        Medium = 2,
        High = 3
    }
    public enum DeliveryFormat
    {
        International = 1,
        SevenBit = 2

    }

    public enum DeliveryMethod
    {
        Network = 1,
        PickupDirectoryFromIis = 2,
        SpecifiedPickupDirectory = 3
    }
}
