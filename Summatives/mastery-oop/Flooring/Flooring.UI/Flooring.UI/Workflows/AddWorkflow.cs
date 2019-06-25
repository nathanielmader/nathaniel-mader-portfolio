using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.BLL;
using Flooring.Models.Responses;
using Flooring.UI;

namespace Flooring.Models.Workflows
{
    public class AddWorkflow
    {
        //Questions/Concerns
        //=================================
        //Order Confirmation - Do I need a response object in case order creation in manager fails?
        //--If so, what to catch?
        public void Execute()
        {
            Manager manager = ManagerFactory.Create();

            string productType = "";
            string stateAbbreviation = "";

            ConsoleIO.Clear();
            ConsoleIO.GeneralPrompt("Add Order");
            ConsoleIO.SeperatorBar();

            DateTime orderDate = ConsoleIO.RetrieveOrderDateFromUser("Enter an order date (Format: MM/DD/YYYY): ");
            ConsoleIO.BlankLine();
            string customerName = ConsoleIO.RetrieveCustomerNameFromUser("Enter a customer name: ");

            while (true)
            {
                ConsoleIO.Clear();
                ConsoleIO.GeneralPrompt("Available States");
                ConsoleIO.SeperatorBar();
                ConsoleIO.BlankLine();

                DisplayStatesResponse response = manager.DisplayStateList();
                if (response.Success)
                {
                    ConsoleIO.DisplayListOfStates(response.States);
                }
                else
                {
                    ConsoleIO.BlankLine();
                    ConsoleIO.GeneralPrompt("An error occurred.");
                    ConsoleIO.GeneralPrompt(response.Message);
                }


                stateAbbreviation = ConsoleIO.RetrieveStateAbbreviationFromUser("Enter a state abbreviation (Example: PA): ");

                StateCheckResponse stateCheckResponse = manager.StateCheckAbbreviationEntry(stateAbbreviation);
                if (stateCheckResponse.Success)
                {
                    break;
                }
                else
                {
                    ConsoleIO.BlankLine();
                    ConsoleIO.GeneralPrompt("An error occurred.");
                    ConsoleIO.GeneralPrompt(stateCheckResponse.Message);
                    ConsoleIO.ReadKeyPlusPrompt("Press any key to try again...");
                }
            }

            //Product Type
            while (true)
            {
                ConsoleIO. Clear();
                ConsoleIO.GeneralPrompt("Available Products");
                ConsoleIO.SeperatorBar();
                ConsoleIO.BlankLine();

                DisplayProductsResponse response = manager.DisplayProductList();

                if (response.Success)
                {
                    ConsoleIO.DisplayListOfProducts(response.Products);
                }
                else
                {
                    ConsoleIO.BlankLine();
                    ConsoleIO.GeneralPrompt("An error occurred.");
                    ConsoleIO.GeneralPrompt(response.Message);
                }


                ConsoleIO.GeneralPrompt("Enter a Product Type (Carpet, Laminate, Tile, Wood)");
                ConsoleIO.BlankLine();

                productType = ConsoleIO.RetrieveProductTypeFromUser("(WARNING: Case Sensitive Entry): ");

                CheckProductResponse checkProductResponse = manager.CheckProductTypeEntry(productType);
                if (checkProductResponse.Success)
                {
                    break;
                }
                else
                {
                    ConsoleIO.BlankLine();
                    ConsoleIO.GeneralPrompt("An error occurred.");
                    ConsoleIO.GeneralPrompt(checkProductResponse.Message);
                    continue;
                }
            }

            //Area
            ConsoleIO.BlankLine();
            decimal area = ConsoleIO.RetrieveAreaSizeFromUser("Enter an area size (Minimum Amount = 100): ");

            //Display Order
            ConsoleIO.Clear();
            ConsoleIO.GeneralPrompt("Here is your order:");
            ConsoleIO.BlankLine();
            Order orderToCreate = manager.CreateNewOrder(orderDate, customerName, stateAbbreviation, productType, area);

            ConsoleIO.DisplaySingleOrder(orderToCreate);

            //Confirm Add Order
            ConsoleIO.GeneralPrompt("Order Confirmation");
            ConsoleIO.SeperatorBar();

            bool addOrderConfirmation = ConsoleIO.Confirmation("Are you sure you would like to create the above order? (Enter Y/N): ");
            if(addOrderConfirmation == true)
            {
                manager.AddOrder(orderToCreate);
                ConsoleIO.BlankLine();
                ConsoleIO.GeneralPrompt("Your order has been added to the system.");
            }
            else
            {
                ConsoleIO.GeneralPrompt("Order Creation Canceled.");
                ConsoleIO.BlankLine();
            }
            ConsoleIO.ReadKeyPlusPrompt("Press any key to continue...");
        }
    }
}
