using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrders
{
    public class LargeRepairOrderNewCustomer : AbstractHandler
    {
        public override object Handle(Request request)
        {
            if (request.IsLargeOrder && request.IsNewCustomer && request.OrderType.Equals(OrderType.Repair.ToString()))
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
