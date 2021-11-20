using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrders
{
    public class LargeRepairOrderNewCustomer : AbstractHandler
    {
        public override object Handle(Request request)
        {
            if (request.IsLargeOrder && request.IsNewCustomer && OrderType.Repair.ToString().Equals(request.OrderType, StringComparison.CurrentCultureIgnoreCase))
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
