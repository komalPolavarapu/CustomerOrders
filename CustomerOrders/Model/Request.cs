using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrders
{
    public class Request
    {
        public bool IsRushOrder { get; set; }

        public bool IsNewCustomer { get; set; }

        public bool IsLargeOrder { get; set; }

        public string OrderType { get; set; }

    }
}
