using Flooring.BLL;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.UI.Workflows
{
    public class RemoveWorkflow
    {
        //Ask date an order number
        //if exizts, display order
        //prompt if want to remove
        //if no, return to main menu
        public void Execute()
        {
            Manager manager = ManagerFactory.Create();

            ConsoleIO.Clear();
            ConsoleIO.GeneralPrompt("Remove Order");
            ConsoleIO.SeperatorBar();

            DateTime orderDate = ConsoleIO.RetrieveOrderDateFromUser("Please Enter a Date (Format: MM/DD/YYYY): ");
            int orderNumber = ConsoleIO.RetrieveOrderNumberFromUser("Please Enter an Order Number: ");



            OrderResponse response = manager.RetrieveOrder(orderDate, orderNumber);//Takes in user entered info, checks 
            if(response.Success)
            {
                ConsoleIO.DisplaySingleOrder(response.Order);
            }
            else
            {
                ConsoleIO.GeneralPrompt("An error occurred.");
                ConsoleIO.GeneralPrompt(response.Message);
            }

            //Remove Confirmation 
            ConsoleIO.GeneralPrompt("Delete Order Confirmation");
            ConsoleIO.BlankLine();
            ConsoleIO.SeperatorBar();

            bool removeOrderConfirmation = ConsoleIO.Confirmation("Would you like to remove this order? (Enter Y/N): ");
            if (removeOrderConfirmation == true)
            {
                manager.DeleteOrder(response.Order);
                ConsoleIO.GeneralPrompt($"Order {orderNumber} for {orderDate} has been removed.");
                ConsoleIO.BlankLine();
            }
            else
            {
                ConsoleIO.Clear();
                ConsoleIO.GeneralPrompt("Order Removal Canceled.");
                ConsoleIO.BlankLine();
            }

            ConsoleIO.ReadKeyPlusPrompt("Press any key to continue...");
        }
    }
}
