using Flooring.Models.Workflows;
using Flooring.UI.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.UI
{
    public class Menu
    {
        public static void Start()
        {
            while (true)//Loop back to menu
            {
                Console.Clear();
                Console.WriteLine("**********************************************************************");
                Console.WriteLine("Flooring Program");
                Console.WriteLine("*");
                Console.WriteLine("1. Display Orders");
                Console.WriteLine("2. Add an Order");
                Console.WriteLine("3. Edit an Order");
                Console.WriteLine("4. Remove an Order");
                Console.WriteLine("5. Quit");
                Console.WriteLine("*");
                Console.WriteLine("**********************************************************************");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DisplayWorkflow displayWorkflow = new DisplayWorkflow();
                        displayWorkflow.Execute();
                        break;
                    case "2":
                        AddWorkflow addWorkflow = new AddWorkflow();
                        addWorkflow.Execute();
                        break;
                    case "3":
                        EditWorkflow editWorkflow = new EditWorkflow();
                        editWorkflow.Execute();
                        break;
                    case "4":
                        RemoveWorkflow removeWorkflow = new RemoveWorkflow();
                        removeWorkflow.Execute();
                        break;
                    case "5":
                        return;
                }
            }

        }
    }
}
