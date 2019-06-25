using Flooring.BLL;
using Flooring.Models;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.UI.Workflows
{
    public class EditWorkflow
    {
        public void Execute()
        {

            Manager manager = ManagerFactory.Create();

            ConsoleIO.Clear();
            ConsoleIO.GeneralPrompt("Edit Order");
            ConsoleIO.SeperatorBar();

            DateTime orderDate = ConsoleIO.RetrieveOrderDateFromUser("Enter an order date (Format: MM/DD/YYYY): ");
            int orderNumber = ConsoleIO.RetrieveOrderNumberFromUser("Enter an order number: ");


            OrderResponse originalOrderResponse = manager.RetrieveOrder(orderDate, orderNumber);//ORIGiNAL/UNTOUCHED ORDER!!!!!!!!!          //Check for existence of order
            if (originalOrderResponse.Success)
            {
                ConsoleIO.DisplaySingleOrder(originalOrderResponse.Order);
            }

            else
            {
                ConsoleIO.GeneralPrompt("An error occurred.");
                ConsoleIO.GeneralPrompt(originalOrderResponse.Message);
            }

            //Customer Name
            ConsoleIO.GeneralPrompt("Enter a new customer name or press enter to continue: ");
            string updatedCustomerName = Console.ReadLine();
            if (string.IsNullOrEmpty(updatedCustomerName))
            {
                updatedCustomerName = originalOrderResponse.Order.CustomerName;//If nothing entered, leave customer name the same
            }

            //State
            string updatedStateAB = "";
            while (true)
            {
                ConsoleIO.Clear();
                ConsoleIO.GeneralPrompt("Available States");
                ConsoleIO.SeperatorBar();
                ConsoleIO.BlankLine();


                DisplayStatesResponse response = new DisplayStatesResponse();
                response = manager.DisplayStateList();

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

                //Attempted to put in IO, not sure how. Problem: need to return string but one possible user submission is emptry string
                ConsoleIO.GeneralPrompt("Enter a new state abbreviation OR press enter to continue: ");
                updatedStateAB = Console.ReadLine().ToUpper();

                if (string.IsNullOrEmpty(updatedStateAB))
                {
                    updatedStateAB = originalOrderResponse.Order.State;
                    break;
                }
                else if (updatedStateAB.Length != 2)
                {
                    ConsoleIO.GeneralPrompt("Error. State abbreviations must be 2 characters in length.");
                    continue;
                }

                StateCheckResponse stateCheckResponse = new StateCheckResponse();
                stateCheckResponse = manager.StateCheckAbbreviationEntry(updatedStateAB);

                if (stateCheckResponse.Success)
                {
                    break;
                }
                else
                {
                    ConsoleIO.BlankLine();
                    ConsoleIO.GeneralPrompt("An error occurred.");
                    ConsoleIO.GeneralPrompt(stateCheckResponse.Message);
                    ConsoleIO.GeneralPrompt("Press any key to try again...");
                    continue;
                }
            }

            //Product Type
            string updatedProductType = "";
            while (true)
            {
                ConsoleIO.Clear();
                ConsoleIO.GeneralPrompt("Available Products");
                ConsoleIO.SeperatorBar();
                ConsoleIO.BlankLine();


                DisplayProductsResponse response = new DisplayProductsResponse();
                response = manager.DisplayProductList();

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

                ConsoleIO.GeneralPrompt("Enter a new product type (Carpet, Laminate, Tile, Wood) OR press enter to continue: ");
                updatedProductType = Console.ReadLine();
                if (string.IsNullOrEmpty(updatedProductType))
                {
                    updatedProductType = originalOrderResponse.Order.ProductType;
                }

                CheckProductResponse checkProductResponse = new CheckProductResponse();
                checkProductResponse = manager.CheckProductTypeEntry(updatedProductType);

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
            decimal updatedAreaSize;
            while (true)
            {
                ConsoleIO.Clear();
                ConsoleIO.GeneralPrompt("Enter a new area size OR press enter to continue: ");
                string updatedAreaSizeString = Console.ReadLine();

                if (string.IsNullOrEmpty(updatedAreaSizeString))
                {
                    updatedAreaSizeString = originalOrderResponse.Order.Area.ToString();
                    updatedAreaSize = decimal.Parse(updatedAreaSizeString);
                    break;
                }
                else if (decimal.TryParse(updatedAreaSizeString, out updatedAreaSize) && updatedAreaSize > 99)
                {
                    ConsoleIO.GeneralPrompt("Area size has been changed.");
                    ConsoleIO.BlankLine();
                    break;
                }
                else
                {
                    ConsoleIO.BlankLine();
                    ConsoleIO.GeneralPrompt("An error occurred.");
                    continue;
                }
            }

            ConsoleIO.Clear();
            ConsoleIO.GeneralPrompt("Updated Order");
            ConsoleIO.SeperatorBar();

            //Calculate remaining fields for order
            Order orderToUpdate = manager.CalculateDisplayUpdateOrder(orderDate, orderNumber, updatedCustomerName, updatedStateAB, updatedProductType, updatedAreaSize);
            //Display order with changes
            ConsoleIO.DisplaySingleOrder(orderToUpdate);

            //Confirm change
            while (true)
            {
                ConsoleIO.GeneralPrompt("Please review the edited order above.");
                bool updateConfirm = ConsoleIO.Confirmation("Are these edits correct? (Enter Y/N): ");
                if (updateConfirm == true)
                {
                    //Call Calculate/Update order AND call repo to change
                    manager.UpdateOrder(orderDate, orderNumber, updatedCustomerName, updatedStateAB, updatedProductType, updatedAreaSize);
                    ConsoleIO.GeneralPrompt("Order edit successful.");
                    break;
                }
                else
                {
                    ConsoleIO.GeneralPrompt("Order edit cancelled.");
                    break;
                }
            }
            ConsoleIO.ReadKeyPlusPrompt("Press any key to continue...");
        }
    }
}
