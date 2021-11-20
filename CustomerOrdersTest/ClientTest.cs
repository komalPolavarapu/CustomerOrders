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

        /// <summary>
        /// Test method for the order status 'closed' 
        /// </summary>
        /// <param name="request"></param>
        [Theory]
        [ClassData(typeof(OrderClosedTestData))]
        public void HandleInputOrderClosedTest(Request request)
        {
            string result = Client.HandleInput(newCustomerLargeRepairOrder, request);

            Assert.Equal("OrderStatus:Closed", result);
        }

        /// <summary>
        /// Test method for the order status 'AuthorisationRequired'
        /// </summary>
        /// <param name="request"></param>
        [Theory]
        [ClassData(typeof(OrderRequiresAuthorisationTestData))]
        public void HandleInputOrderRequiresAuthorisationTest(Request request)
        {
            string result = Client.HandleInput(newCustomerLargeRepairOrder, request);

            Assert.Equal("OrderStatus:AuthorisationRequired", result);
        }

        /// <summary>
        /// Test method for the order status 'Confirmed'
        /// </summary>
        /// <param name="request"></param>
        [Theory]
        [ClassData(typeof(OrderConfirmedTestData))]
        public void HandleInputOrderConfirmedTest(Request request)
        {
            string result = Client.HandleInput(newCustomerLargeRepairOrder, request);

            Assert.Equal("OrderStatus:Confirmed", result);
        }
    }

    /// <summary>
    /// Test data for the order status 'closed'
    /// </summary>
    public class OrderClosedTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Request { IsLargeOrder = true, OrderType = OrderType.Repair.ToString(), IsNewCustomer = true, IsRushOrder = true } };
            yield return new object[] { new Request { IsLargeOrder = true, OrderType = OrderType.Repair.ToString(), IsNewCustomer = true, IsRushOrder = false } };
            yield return new object[] { new Request { IsLargeOrder = true, OrderType = OrderType.Hire.ToString(), IsRushOrder = true, IsNewCustomer = true } };
            yield return new object[] { new Request { IsLargeOrder = true, OrderType = OrderType.Hire.ToString(), IsRushOrder = true, IsNewCustomer = true } };

        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    /// <summary>
    /// Test data for the order status 'requires authorisation'
    /// </summary>
    public class OrderRequiresAuthorisationTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Request { IsLargeOrder = true, OrderType = OrderType.Repair.ToString(), IsNewCustomer = false,IsRushOrder=false } };
            yield return new object[] { new Request { IsLargeOrder = true, OrderType = OrderType.Repair.ToString(), IsNewCustomer = false, IsRushOrder = true } };
            yield return new object[] { new Request { IsLargeOrder = false, OrderType = OrderType.Hire.ToString(), IsRushOrder = true, IsNewCustomer = true } };
            yield return new object[] { new Request { IsLargeOrder = false, OrderType = OrderType.Repair.ToString(), IsRushOrder = true, IsNewCustomer = true } };

        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    /// <summary>
    /// Test data for the order status 'confirmed'
    /// </summary>
    public class OrderConfirmedTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Request { IsLargeOrder = false, OrderType = OrderType.Repair.ToString(), IsNewCustomer = false, IsRushOrder = false } };
            yield return new object[] { new Request { IsLargeOrder = false, OrderType = OrderType.Hire.ToString(), IsNewCustomer = false, IsRushOrder = false } };
            yield return new object[] { new Request { IsLargeOrder = false, OrderType = OrderType.Repair.ToString(), IsNewCustomer = true, IsRushOrder = false } };
            yield return new object[] { new Request { IsLargeOrder = false, OrderType = OrderType.Hire.ToString(), IsNewCustomer = true, IsRushOrder = false } };
            yield return new object[] { new Request { IsLargeOrder = true, OrderType = OrderType.Hire.ToString(), IsNewCustomer = true, IsRushOrder = false } };
            yield return new object[] { new Request { IsLargeOrder = true, OrderType = OrderType.Hire.ToString(), IsNewCustomer = false, IsRushOrder = false } };
            yield return new object[] { new Request { IsLargeOrder = false, OrderType = OrderType.Hire.ToString(), IsNewCustomer = false, IsRushOrder = true } };
            yield return new object[] { new Request { IsLargeOrder = false, OrderType = OrderType.Repair.ToString(), IsNewCustomer = false, IsRushOrder = true } };
            
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
