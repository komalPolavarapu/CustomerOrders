
namespace CustomerOrders
{
    public class RushOrderNewCustomer:AbstractHandler
    {
        /// <summary>
        ///  If the order is a Rush order for new customer return status as AuthorisationRequired else send the request to the next handler
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
