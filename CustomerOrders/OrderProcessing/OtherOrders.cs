namespace CustomerOrders
{
    public class OtherOrders:AbstractHandler
    {
        /// <summary>
        /// Return the order status as confirmed
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override object Handle(Request request)
        {

            return OrderStatus.Confirmed;

        }
    }
}
