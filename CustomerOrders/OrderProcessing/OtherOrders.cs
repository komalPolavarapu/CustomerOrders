using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrders
{
    public class OtherOrders:AbstractHandler
    {
        public override object Handle(Request request)
        {

            return OrderStatus.Confirmed;

        }
    }
}
