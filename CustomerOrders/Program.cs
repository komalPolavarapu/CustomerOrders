using CustomerOrders.ChainBuilder;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerOrders
{
    class Program
    {
        static void Main(string[] args)
        {
            LargeRepairOrderNewCustomer largeRepairOrderNewCustomer = new LargeRepairOrderNewCustomer();
            LargeRushHireOrder largeRushHireOrder = new LargeRushHireOrder();
            LargeRepairOrders largeRepairOrders = new LargeRepairOrders();
            RushOrderNewCustomer rushOrderNewCustomer = new RushOrderNewCustomer();
            OtherOrders otherOrders = new OtherOrders();

            largeRepairOrderNewCustomer.SetNext(largeRushHireOrder).SetNext(largeRepairOrders).SetNext(rushOrderNewCustomer).SetNext(otherOrders);

            Client.ClientCode(largeRepairOrderNewCustomer);
        }       
    }
}
