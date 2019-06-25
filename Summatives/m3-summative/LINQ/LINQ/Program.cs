using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {

        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();
            //Exercise1(); check
            //Exercise2();
            //Exercise3();
            //Exercise4();
            //Exercise5();
            //Exercise6();
            //Exercise7();
            //Exercise8();
            //Exercise9();
            //Exercise10();
            //Exercise11();
            //Exercise12();
            //Exercise13();
            //Exercise14();
            //Exercise15();
            //Exercise16();
            //Exercise17();
            //Exercise18();
            //Exercise19();
            //Exercise20();
            //Exercise21(); Awful
            //Exercise22();
            //Exercise23();
            //Exercise24();
            //Exercise25();
            //Exercise26();
            //Exercise27();
            //Exercise28();
            //Exercise29();
            //Exercise30();
            Exercise31();


            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            var products = DataLoader.LoadProducts().Where(p => p.UnitsInStock < 1);
            PrintProductInformation(products);
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            var products = DataLoader.LoadProducts().Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00M);
            PrintProductInformation(products);
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            var customers = DataLoader.LoadCustomers().Where(c => c.Region == "WA");
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            var products = from p in DataLoader.LoadProducts()
                           select new
                           {
                               p.ProductName
                           };

            foreach (var product in products)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {

            var products = from p in DataLoader.LoadProducts()
                           select new
                           {
                               pID = p.ProductID,
                               p.ProductName,
                               p.Category,
                               newPrice = p.UnitPrice * 1.25M,
                               p.UnitsInStock
                           };

            string line = "{0,-5} {1,-35} {2,-15} {3,7:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.pID, product.ProductName, product.Category, product.newPrice, product.UnitsInStock);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            string line = "{0,-35} {1,-15}";
            var products = from p in DataLoader.LoadProducts()
                           select new
                           {
                               p.ProductName,
                               p.Category,
                           };

            Console.WriteLine(line, "Product Name", "Category");
            Console.WriteLine("==============================================================================");
            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductName.ToUpper(), product.Category.ToUpper());
            }

        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {

            var products = from p in DataLoader.LoadProducts()
                           select new
                           {
                               pID = p.ProductID,//to string
                               p.ProductName,
                               p.Category,
                               p.UnitPrice,
                               p.UnitsInStock,
                               ReOrder = (p.UnitsInStock < 3) ? true : false
                           };

            string line = "{0,-5} {1,-35} {2,-15} {3,7:c} {4,6} {5,10}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "ReOrder");
            Console.WriteLine("===================================================================================");
            foreach (var product in products)
            {
                Console.WriteLine(line, product.pID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock, product.ReOrder);
            }

        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            var products = from p in DataLoader.LoadProducts()
                           select new
                           {
                               pID = p.ProductID,
                               p.ProductName,
                               p.Category,
                               p.UnitPrice,
                               p.UnitsInStock,
                               StockValue = p.UnitPrice * p.UnitsInStock
                           };

            string line = "{0,-5} {1,-35} {2,-15} {3,7:c} {4,8} {5,14}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "StockValue");
            Console.WriteLine("=========================================================================================");
            foreach (var product in products)
            {
                Console.WriteLine(line, product.pID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock, product.StockValue);
            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            var even = DataLoader.NumbersA.Where(n => n % 2 == 0);
            foreach (var num in even)
            {
                Console.WriteLine(num);
            }
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            var customers = DataLoader.LoadCustomers().Where(c => c.Orders.Any(o => o.Total < 500));
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            var odd3 = DataLoader.NumbersC.Where(c => c % 2 != 0).Take(3);
            foreach (var n in odd3)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            var numbers = from n in DataLoader.NumbersB.Skip(3)
                          select n;
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            var customers = from c in DataLoader.LoadCustomers().Where(c => c.Region == "WA")
                            select new
                            {
                                c.CompanyName,
                                mostRecentOrder = c.Orders.OrderByDescending(x => x.OrderDate).First()
                            };

            string line = "{0,-35} {1,-15} {2,-25} {3,-40}";
            Console.WriteLine(line, "Company Name", "Order ID", "Order Date", "Order Total");
            Console.WriteLine("======================================================================================");
            foreach (var customer in customers)
            {
                Console.WriteLine(line, customer.CompanyName, customer.mostRecentOrder.OrderID, customer.mostRecentOrder.OrderDate, customer.mostRecentOrder.Total);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            var numbers = DataLoader.NumbersC.TakeWhile(n => n < 7);
            foreach(var number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            var numbers = DataLoader.NumbersC.SkipWhile(n => n % 3 != 0).Skip(1);
            foreach(var number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            var products = DataLoader.LoadProducts().OrderBy(p => p.ProductName);
            PrintProductInformation(products);
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            var products = DataLoader.LoadProducts().OrderByDescending(p => p.UnitsInStock);
            PrintProductInformation(products);
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            var products = DataLoader.LoadProducts().OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
            PrintProductInformation(products);
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            var numbers = DataLoader.NumbersB.Reverse();
            foreach(var number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            var category = DataLoader.LoadProducts().GroupBy(p => p.Category);
            foreach(var cat in category)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(cat.Key);
                Console.WriteLine("--------------------------");
                foreach (var product in cat)
                {
                    Console.WriteLine(product.ProductName);
                }
            }
        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {

        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            var products = DataLoader.LoadProducts().Select(p => p.Category).Distinct();
            foreach(var product in products)
            {
                Console.WriteLine(product);
            }
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            var products = DataLoader.LoadProducts().Any(p => p.ProductID == 789);
            Console.WriteLine(products);
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            var products = from p in DataLoader.LoadProducts().OrderBy(p => p.Category).Where(p => p.UnitsInStock == 0)
                           select new
                           {
                               p.Category
                           };
            foreach(var product in products.Distinct())
            {
                Console.WriteLine(product.Category);
            }
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            var products = DataLoader.LoadProducts().GroupBy(p => p.Category).Where(x => x.All(p => p.UnitsInStock != 0));

            foreach (var product in products)
            {
                Console.WriteLine(product.Key);
            }
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            var numbers = DataLoader.NumbersA.Where(n => n % 2 == 1).Count();
            Console.WriteLine(numbers);
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            var customers = from c in DataLoader.LoadCustomers()
                            select new
                            {
                                c.CustomerID,
                                count = c.Orders.Count()
                            };

            string line = "{0, -18} {1, -20}";
            Console.WriteLine(line, "Customer ID", "Order Count");
            Console.WriteLine("==============================================");
            foreach (var customer in customers)
            {
                Console.WriteLine(line, customer.CustomerID, customer.count);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            var products = from p in DataLoader.LoadProducts().GroupBy(p => p.Category)
                select new
                {
                    cat = p.Key,
                    count = p.Count()
                };

            string line = "{0, -20} {1, -20}";
            Console.WriteLine(line, "Category", "Product Count");
            Console.WriteLine("=======================================");
            foreach (var product in products)
            {
                Console.WriteLine(line, product.cat, product.count);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            var products = from p in DataLoader.LoadProducts().GroupBy(p => p.Category)
                           select new
                           {
                               cat = p.Key,
                               count = p.Sum(x => x.UnitsInStock)
                           };

            string line = "{0, -20} {1, -20}";
            Console.WriteLine(line, "Category", "Units in Stock");
            Console.WriteLine("=======================================");
            foreach (var product in products)
            {
                Console.WriteLine(line, product.cat, product.count);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            var products = from p in DataLoader.LoadProducts().GroupBy(p => p.Category)
                             select new
                             {
                                 cat = p.Key,
                                 price = p.Min(x => x.UnitPrice),
                                 lowProduct = p.Where(x => x.UnitPrice == p.Min(o => o.UnitPrice)).First().ProductName
                             };

            string line = "{0, -20} {1, -30} {2, -40}";
            Console.WriteLine(line, "Category", "Lowest Priced Product", "Price");
            Console.WriteLine("============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.cat, product.lowProduct, product.price);
            }

        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            var products = DataLoader.LoadProducts().GroupBy(c => c.Category).OrderByDescending(c => c.Average(p => p.UnitPrice)).Take(3);

            Console.WriteLine("Top Three Categories");
            Console.WriteLine("*************************************");
            foreach (var product in products)
            {
                Console.WriteLine(product.Key);
                Console.WriteLine("Average Unit Price: {0}", product.Average(p => p.UnitPrice));
                Console.WriteLine();
            }
        }
    }
}
