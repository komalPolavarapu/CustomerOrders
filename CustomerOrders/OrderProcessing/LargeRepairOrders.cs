using System;

namespace CustomerOrders
{
    public class LargeRepairOrders : AbstractHandler
    {
        /// <summary>
        /// If the order is a Large Repair Order return status as AuthorisationRequired else send the request to the next handler
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
