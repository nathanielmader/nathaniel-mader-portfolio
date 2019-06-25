using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMManager.View;
using SMManager.Data;
using SMManager.Models;

namespace SMManager.Controllers
{
    public class SMController
    {
        SMRepository repo = new SMRepository();
        SMView view = new SMView();
        public void Run()
        {

            SMView view = new SMView();
            while (true)
            {
                int choice = view.GetMenuChoice();

                switch (choice)
                {
                    case 1://Typically instantiate create workflow object. Call execute method. Ex:
                           //CreateSnakeWorkflow createSnakeWorkflow = new CreateSnakeWorkflow();
                           //createSnakeWorkflow.Execute();
                        CreateSnake();
                        break;
                    case 2:
                        DisplaySnakes();
                        break;
                    case 3:
                        SearchSnakes();
                        break;
                    case 4:
                        EditSnake();
                        break;
                    case 5:
                        RemoveSnake();
                        break;
                    case 6:
                        return;
                    default:
                        break;

                }
            }
        }


        public void CreateSnake()//Create Snake
        {
            view.WorkFlowHeader("Create/Add Snake");
            Snake snakeToCreate = view.GetNewSnakeInfo();//Returns a snake object, set to snakeToCreate
            Console.Clear();

            repo.Create(snakeToCreate);
            view.DisplaySnake(snakeToCreate);
            Console.WriteLine();//Question is, did it add to _snakeList??? A feeling it did not
            view.GeneralWriteLine("Your snake has been added to the system.");
            Console.ReadKey();

        }


        public void DisplaySnakes()//List All Snakes //WORKS--NO WORK NEEDED
        {
            view.WorkFlowHeader("Display Snakes");

            view.GeneralWriteLine("Here are the snakes currently in our system");
            List<Snake> snakesToDisplay = repo.ReadAll();
            foreach (var snake in snakesToDisplay)
            {
                view.DisplaySnake(snake);
            }

            view.GeneralWriteLine("Press any key to continue.");
            Console.ReadKey();
        }


        public void SearchSnakes()//Find Snake By ID //WORKS--NO WORK NEEDED
        {
            view.WorkFlowHeader("Search Snakes");
            while (true)
            {
                int numberID = view.SearchSnake();//returns int, set to numberID
                Snake snakeToSearch = repo.ReadByID(numberID);//Plug in Snake ID#, return snake from snakelist with equivalent id#
                view.DisplaySnake(snakeToSearch);
                if (view.ConfirmSnakeLookingFor(snakeToSearch) == true)
                {
                    break;
                }
                else
                {
                    continue;
                }
            }

        }


        public void EditSnake()//Edit Snake //NEEDS LOTS OF WORK
        {
            view.WorkFlowHeader("Edit Snake");

            List<Snake> snakesToDisplay = repo.ReadAll();
            foreach (var snake in snakesToDisplay)
            {
                view.DisplaySnake(snake);
            }

            view.GeneralWriteLine("Which snake would you like to edit?: ");
            int idToEdit = view.SearchSnake();
            Snake snakeToEdit = repo.ReadByID(idToEdit);
            view.EditSnake(snakeToEdit);
            repo.Update(snakeToEdit.ID, snakeToEdit);
            view.DisplaySnake(snakeToEdit);
            Console.ReadLine();

        }


        public void RemoveSnake()//Remove Snake //NEEDS LOTS OF WORK
        {
            view.WorkFlowHeader("Remove Snake");

            List<Snake> snakesToDisplay = repo.ReadAll();
            foreach (var snake in snakesToDisplay)
            {
                view.DisplaySnake(snake);
            }

            while (true)
            {
                view.GeneralWriteLine("Which snake would you like to remove?");
                int idToRemove = view.SearchSnake();
                Snake snakeToRemove = repo.ReadByID(idToRemove);
                if (view.ConfirmRemoveSnake(snakeToRemove) == true)
                {
                    repo.Delete(snakeToRemove.ID);
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
