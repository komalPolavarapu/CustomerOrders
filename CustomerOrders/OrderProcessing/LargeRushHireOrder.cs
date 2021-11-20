using System;

namespace CustomerOrders
{
    public class LargeRushHireOrder:AbstractHandler
    {
        /// <summary>
        ///  If the order is a Large Rush Hire Order return status as Closed else send the request to the next handler
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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

