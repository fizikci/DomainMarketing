using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.Response
{
    public class PagerResponse<T>
    {
        public List<T> ItemsInPage { get; set; }
        public int NumberOfItemsInTotal { get; set; }
    }
}
