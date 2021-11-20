using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrders
{
    public class Client
    {
        public static void ClientCode(AbstractHandler handler)
        {
            while (true)
            {
                Request request = UserInput();
                Console.WriteLine(HandleInput(handler, request));                
            }
        }

        public static string  HandleInput(AbstractHandler handler, Request request)
        {
            var result = handler.Handle(request);

            if (result != null)
            {                
                return "OrderStatus:" + result;               
            }
            else
            {
                return "unable to process the request";
            }
        }

        public static Request UserInput()
        {
            Request request = new Request();

            request.IsLargeOrder = ValidateBooleanInput("Is Large Order");
            request.OrderType = ValidateOrderType();
            request.IsNewCustomer = ValidateBooleanInput("Is New Customer");
            request.IsRushOrder = ValidateBooleanInput("Is Rush Order");

            return request;
        }

        public static bool ValidateBooleanInput(string question)
        {
            while (true)
            {
                Console.Write($"{question}(Y/N):");
                string isRushOrder = Console.ReadLine();
                if (isRushOrder.ToUpper().Equals("Y"))
                {
                    return true;
                }
                else if (isRushOrder.ToUpper().Equals("N"))
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please input only Y or N");
                }
            }
        }

        public static string ValidateOrderType()
        {
            while (true)
            {
                Console.Write($"Order Type(Hire/Repair):");
                string isRushOrder = Console.ReadLine();
                if (isRushOrder.Equals(OrderType.Hire.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    return OrderType.Hire.ToString();
                }
                else if (isRushOrder.ToUpper().Equals(OrderType.Repair.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    return OrderType.Repair.ToString();
                }
                else
                {
                    Console.WriteLine("Please input only Hire or Repair");
                }
            }
        }
    }
}
