using System;

namespace CustomerOrders
{
    public class Client
    {
        /// <summary>
        /// Repeating the questions for the next order
        /// </summary>
        /// <param name="handler"></param>
        public static void Execute(AbstractHandler handler)
        {
            do
            {
                Request request = UserInput();
                Console.WriteLine(HandleInput(handler, request));
            } while (ValidateBooleanInput("Do you want to continue"));
        }

        /// <summary>
        /// Process the input
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="request"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get the required data from the user
        /// </summary>
        /// <returns></returns>
        public static Request UserInput()
        {
            Request request = new Request();

            request.IsLargeOrder = ValidateBooleanInput("Is Large Order");
            request.OrderType = ValidateOrderType();
            request.IsNewCustomer = ValidateBooleanInput("Is New Customer");
            request.IsRushOrder = ValidateBooleanInput("Is Rush Order");

            return request;
        }

        /// <summary>
        /// Repeat the question until Y/N is inputted
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
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

        /// <summary>
        /// repeat the question until valid order type is inputted
        /// </summary>
        /// <returns></returns>
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
