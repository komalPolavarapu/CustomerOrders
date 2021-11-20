using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrders
{
    public class LargeRushHireOrder:AbstractHandler
    {
        public override object Handle(Request request)
        {
            if (request.IsLargeOrder && request.IsRushOrder && request.OrderType.Equals(OrderType.Hire.ToString()))
            {
                return "closed";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}

