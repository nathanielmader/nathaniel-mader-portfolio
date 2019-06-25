using Flooring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.UI
{
    public class ConsoleIO
    {

        //public static void TryAgainPrompt()
        //{
        //    Console.WriteLine("Press any key to try again...");
        //    Console.ReadKey();
        //}
        public static void ReadKeyPlusPrompt(string prompt)
        {
            Console.WriteLine(prompt);
            Console.ReadKey();
        }
        public static void SeperatorBar()
        {
            Console.WriteLine("=================================================================");
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static void BlankLine()
        {
            Console.WriteLine();
        }
        public static void GeneralPrompt(string prompt)
        {
            Console.WriteLine(prompt);
        }

        public static void DisplaySingleOrder(Order order)
        {
            Console.WriteLine("==============================");
            Console.WriteLine($"{order.OrderNumber}   |   {order.OrderDate.ToString()}");
            Console.WriteLine($"{order.CustomerName}");
            Console.WriteLine($"{order.State}");
            Console.WriteLine($"Product: {order.ProductType}");
            Console.WriteLine($"Materials: {order.MaterialCost:c}");
            Console.WriteLine($"Labor: {order.LaborCost:c}");
            Console.WriteLine($"Tax: {order.Tax:c}");
            Console.WriteLine($"Total: {order.Total:c}");
            Console.WriteLine("==============================");
            Console.WriteLine();
        }

        public static void DisplayListOfOrders(List<Order> orders)
        {
            foreach (var order in orders)
            {
                Console.WriteLine("==============================");
                Console.WriteLine($"{order.OrderNumber}   |   {order.OrderDate.ToString()}");
                Console.WriteLine($"{order.CustomerName}");
                Console.WriteLine($"{order.State}");
                Console.WriteLine($"Product: {order.ProductType}");
                Console.WriteLine($"Materials: {order.MaterialCost:c}");
                Console.WriteLine($"Labor: {order.LaborCost:c}");
                Console.WriteLine($"Tax: {order.Tax:c}");
                Console.WriteLine($"Total: {order.Total:c}");
                Console.WriteLine("==============================");
                Console.WriteLine();
            }
        }


        public static DateTime RetrieveOrderDateFromUser(string prompt)
        {
            DateTime orderDate;

            while (true)
            {
                Console.Clear();
                Console.Write(prompt);
                string dateEnteredStringFormat = Console.ReadLine();

                if (!DateTime.TryParse(dateEnteredStringFormat, out orderDate))
                {
                    Console.WriteLine("Error. Invalid Entry.");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                }
                else if (orderDate < DateTime.Today)
                {
                    Console.WriteLine("Error. Order date cannot be in the past.");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                }
                else
                {
                    orderDate = DateTime.Parse(dateEnteredStringFormat);
                    return orderDate;
                }
            }
        }



        public static string RetrieveCustomerNameFromUser(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string customerName = Console.ReadLine();

                if (string.IsNullOrEmpty(customerName))
                {
                    Console.WriteLine("Error. Customer name cannot be blank.");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();

                }
                else
                {
                    return customerName;
                }
            }
        }


        public static string RetrieveStateAbbreviationFromUser(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string stateAbbreviation = Console.ReadLine().ToUpper();

                if (string.IsNullOrEmpty(stateAbbreviation) || stateAbbreviation.Length != 2)
                {
                    Console.WriteLine("An error occurred. Entry must NOT be blank and must be two letters in length.");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                }
                else
                {
                    return stateAbbreviation;
                }
            }
        }


        public static void DisplayListOfStates(List<Taxes> states)
        {
            foreach (var state in states)
            {

                Console.WriteLine($"State Abbreviation: {state.StateAbbreviation}");
                Console.WriteLine($"State Name: {state.StateName}");
                Console.WriteLine($"State Tax Rate: {state.TaxRate}");
                Console.WriteLine();
            }
        }


        public static void DisplayListOfProducts(List<Products> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"Product Type: {product.ProductType}");
                Console.WriteLine($"Product Cost Per Square Foot: {product.CostPerSquareFoot:c}");
                Console.WriteLine($"Product Labor Cost Per Square Foot: {product.LaborCostPerSquareFoot:c}");
                Console.WriteLine();
            }
        }


        public static int RetrieveOrderNumberFromUser(string prompt)
        {
            int orderNumber;

            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                if (!int.TryParse(input, out orderNumber) && orderNumber > 0)
                {
                    Console.WriteLine("Error. Invalid Entry (MUST be an integer greater than zero).");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                }
                else
                {
                    orderNumber = int.Parse(input);
                    return orderNumber;
                }
            }
        }

        public static string RetrieveProductTypeFromUser(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string productType = Console.ReadLine();

                if (string.IsNullOrEmpty(productType))
                {
                    Console.WriteLine("Error. Entry was blank.");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                }
                else
                {
                    return productType;
                }
            }
        }

        //Must be minimum
        public static decimal RetrieveAreaSizeFromUser(string prompt)
        {
            decimal area;

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!decimal.TryParse(input, out area))
                {
                    Console.WriteLine("Error. Invalid Entry.");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                }
                else if (area < 100)
                {
                    Console.WriteLine("Error. Invalid Entry. Area must be at least 100.");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                }
                else
                {
                    area = decimal.Parse(input);
                    return area;
                }
            }
        }

        public static bool Confirmation(string prompt)
        {
            bool validate;
            while (true)
            {
                Console.Write(prompt);
                string confirmation = Console.ReadLine().ToUpper();

                if (confirmation == "Y" || confirmation == "YES" || confirmation == "Yes")
                {
                    validate = true;
                    return validate;
                }
                else if (confirmation == "N" || confirmation == "NO" || confirmation == "No")
                {
                    validate = false;
                    return validate;
                }
                else if (string.IsNullOrEmpty(confirmation))
                {
                    Console.WriteLine("Error. Entry may not be blank.");
                    Console.WriteLine("Please try again...");
                    Console.WriteLine();
                    continue;
                }
                else
                {
                    Console.WriteLine("An error occurred.");
                    Console.WriteLine("Please try again...");
                    Console.WriteLine();
                    continue;
                }
            }
        }

        //public static string NewStateIDValidation(string prompt)
        //{
        //    string doNotChange = "";
        //    bool change;
        //    while (true)
        //    {
        //        Console.Write(prompt);
        //        string confirmation = Console.ReadLine().ToUpper();

        //        if (string.IsNullOrEmpty(confirmation))
        //        {
        //            change = false;
        //            confirmation = doNotChange;
        //            return confirmation;
        //        }
        //        else if (confirmation.Length != 2)
        //        {
        //            Console.WriteLine("Error. State abbreviation length must be equal to 2.");
        //            Console.WriteLine("Please try again...");
        //            Console.WriteLine();
        //            continue;
        //        }
        //        else
        //        {
        //            change = true;
        //            return confirmation;
        //        }
        //    }
        //}
    }
}
