using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrders
{
    public class LargeRepairOrders : AbstractHandler
    {
        public override object Handle(Request request)
        {
            if (request.IsLargeOrder && request.OrderType.Equals(OrderType.Repair.ToString(),StringComparison.CurrentCultureIgnoreCase))
            {
                return "requires authorisation";
            }
            else
            {
                return base.Handle(request);
            }
        }
     }
}
