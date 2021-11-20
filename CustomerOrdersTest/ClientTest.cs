using System;
using Xunit;
using CustomerOrders;
using System.Collections.Generic;
using System.Collections;

namespace CustomerOrdersTest
{
    public class ClientTest
    {
        LargeRepairOrderNewCustomer newCustomerLargeRepairOrder = new LargeRepairOrderNewCustomer();
        LargeRushHireOrder largeRushHireOrder = new LargeRushHireOrder();
        LargeRepairOrders largeRepairOrders = new LargeRepairOrders();
        RushOrderNewCustomer newCustomerRushOrder = new RushOrderNewCustomer();
        OtherOrders otherOrders = new OtherOrders();

        public ClientTest()
        {

            newCustomerLargeRepairOrder.SetNext(largeRushHireOrder).SetNext(largeRepairOrders).SetNext(newCustomerRushOrder).SetNext(otherOrders);

        }

        //public static IEnumerable<object[]> OrderClosedData =>
        //new List<object[]>
        //{
        //    new object[] { IsLargeOrder=true,OrderType=OrderType.Repair.ToString(),IsNewCustomer=true },
        //    new object[] { IsLargeOrder=true,OrderType=OrderType.Hire.ToString(),IsNewCustomer=false,IsRushOrder=true }
        //};


        [Theory]
        [ClassData(typeof(OrderClosedTestData))]
        public void OrderClosedTest(Request request)
        {
            string result = Client.HandleInput(newCustomerLargeRepairOrder, request);

            Assert.Equal("Order closed", result);
        }

        [Theory]
        [ClassData(typeof(OrderRequiresAuthorisationTestData))]
        public void OrderRequiresAuthorisationTest(Request request)
        {
            string result = Client.HandleInput(newCustomerLargeRepairOrder, request);

            Assert.Equal("Order requires authorisation", result);
        }

        [Theory]
        [ClassData(typeof(OrderConfirmedTestData))]
        public void OrderConfirmedTest(Request request)
        {
            string result = Client.HandleInput(newCustomerLargeRepairOrder, request);

            Assert.Equal("Order confirmed", result);
        }
    }

    public class OrderClosedTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Request { IsLargeOrder = true, OrderType = OrderType.Repair.ToString(), IsNewCustomer = true, IsRushOrder = true } };
            yield return new object[] { new Request { IsLargeOrder = true, OrderType = OrderType.Repair.ToString(), IsNewCustomer = true, IsRushOrder = false } };
            yield return new object[] { new Request() { IsLargeOrder = true, OrderType = OrderType.Hire.ToString(), IsRushOrder = true, IsNewCustomer = true } };
            yield return new object[] { new Request() { IsLargeOrder = true, OrderType = OrderType.Hire.ToString(), IsRushOrder = true, IsNewCustomer = true } };

        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class OrderRequiresAuthorisationTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Request { IsLargeOrder = true, OrderType = OrderType.Repair.ToString(), IsNewCustomer = false,IsRushOrder=false } };
            yield return new object[] { new Request { IsLargeOrder = true, OrderType = OrderType.Repair.ToString(), IsNewCustomer = false, IsRushOrder = false } };
            yield return new object[] { new Request() { IsLargeOrder = false, OrderType = OrderType.Hire.ToString(), IsRushOrder = true, IsNewCustomer = true } };
            yield return new object[] { new Request() { IsLargeOrder = false, OrderType = OrderType.Repair.ToString(), IsRushOrder = true, IsNewCustomer = true } };

        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class OrderConfirmedTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Request { IsLargeOrder = false, OrderType = OrderType.Repair.ToString(), IsNewCustomer = false, IsRushOrder = false } };
            yield return new object[] { new Request { IsLargeOrder = false, OrderType = OrderType.Hire.ToString(), IsNewCustomer = false, IsRushOrder = false } };
            yield return new object[] { new Request() { IsLargeOrder = false, OrderType = OrderType.Repair.ToString(), IsNewCustomer = true, IsRushOrder = false } };
            yield return new object[] { new Request() { IsLargeOrder = false, OrderType = OrderType.Hire.ToString(), IsNewCustomer = true, IsRushOrder = false } };

        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
