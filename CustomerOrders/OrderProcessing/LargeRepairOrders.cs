using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrders
{
    public class LargeRepairOrders : AbstractHandler
    {
        public override object Handle(Request request)
        {
            if (request.IsLargeOrder && OrderType.Repair.ToString().Equals(request.OrderType, StringComparison.CurrentCultureIgnoreCase))
            {
                return OrderStatus.AuthorisationRequired;
            }
            else
            {
                return base.Handle(request);
            }
        }
     }
}
