using System;

namespace CustomerOrders
{
    public class LargeRepairOrderNewCustomer : AbstractHandler
    {
        /// <summary>
        /// If the order is a Large Repair Order for New customer return status as closed else send the request to the next handler
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
