using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrders
{
    public class LargeRushHireOrder:AbstractHandler
    {
        public override object Handle(Request request)
        {
            if (request.IsLargeOrder && request.IsRushOrder && OrderType.Hire.ToString().Equals(request.OrderType, StringComparison.CurrentCultureIgnoreCase))
            {
                return OrderStatus.Closed;
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}

