using Flooring.BLL;
using Flooring.Models.Responses;
using Flooring.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Workflows
{
    public class DisplayWorkflow
    {
        public void Execute()
        {
            Manager manager = ManagerFactory.Create();

            ConsoleIO.Clear();
            ConsoleIO.GeneralPrompt("Display Orders");
            ConsoleIO.SeperatorBar();

            DateTime orderDate = ConsoleIO.RetrieveOrderDateFromUser("Enter an order date (Format: MM/DD/YYYY): ");


            DisplayOrdersResponse response = manager.DisplayOrders(orderDate);
            if (response.Success)
            {
                ConsoleIO.Clear();
                ConsoleIO.GeneralPrompt($"Orders currently in system ({orderDate.ToString()}): ");
                ConsoleIO.SeperatorBar();
                ConsoleIO.BlankLine();
                ConsoleIO.DisplayListOfOrders(response.Orders);
            }
            else
            {
                ConsoleIO.GeneralPrompt("An error occurred.");
                Console.WriteLine(response.Message);
            }

            ConsoleIO.ReadKeyPlusPrompt("Press any key to continue...");
        }
    }
}
