using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrders
{
    public class RushOrderNewCustomer:AbstractHandler
    {
        public override object Handle(Request request)
        {
            if (request.IsNewCustomer && request.IsRushOrder)
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
