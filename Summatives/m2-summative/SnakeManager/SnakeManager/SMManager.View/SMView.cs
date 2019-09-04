using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMManager.Models;

namespace SMManager.View
{
    public class SMView
    {
        public int GetMenuChoice()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("-----Snake Manager Menu-----");
                Console.WriteLine();
                Console.WriteLine("Please choose one of the following (Enter 1-6): ");
                Console.WriteLine("1. Create Snake");
                Console.WriteLine("2. List All Snakes");
                Console.WriteLine("3. Find Snake By ID");
                Console.WriteLine("4. Edit Snake");
                Console.WriteLine("5. Remove Snake");
                Console.WriteLine("6. Quit");
                Console.WriteLine();

                string input = Console.ReadLine();
                int choice;
                if (int.TryParse(input, out choice) && choice >= 1 && choice <= 6)
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Invalid Entry. Please enter an integer between 1 and 6.");
                    continue;
                }
            }
        }


        public int GetSnakeEditChoice()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Which part would you like to edit?");
                Console.WriteLine();
                Console.WriteLine("Choose one of the following options:");
                Console.WriteLine("1. Species");
                Console.WriteLine("2. Length");
                Console.WriteLine("3. Quit");

                string input = Console.ReadLine();
                int choice;
                if (int.TryParse(input, out choice) && choice >= 1 && choice <= 3)
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Invalid Entry. Please enter an integer between 1 and 3.");
                    continue;
                }
            }
        }
        public Snake GetNewSnakeInfo()
        {
            Snake snake = new Snake();


            Random id = new Random();
            snake.ID = id.Next(500);


            while (true)
            {
                DisplaySpeciesChoices();

                string family = Console.ReadLine();

                switch (family)
                {
                    case "1":
                        snake.Family = SnakeFamily.Viperidae;
                        snake.Venomous = true;
                        snake.CommonSpeciesName = "Timber Rattlesnake";
                        break;
                    case "2":
                        snake.Family = SnakeFamily.Viperidae;
                        snake.Venomous = true;
                        snake.CommonSpeciesName = "North American Cooperhead";
                        break;
                    case "3":
                        snake.Family = SnakeFamily.Boidae;
                        snake.Venomous = false;
                        snake.CommonSpeciesName = "Boa Constrictor";
                        break;
                    case "4":
                        snake.Family = SnakeFamily.Boidae;
                        snake.Venomous = false;
                        snake.CommonSpeciesName = "Green Anaconda";
                        break;
                    case "5":
                        snake.Family = SnakeFamily.Colubridae;
                        snake.Venomous = false;
                        snake.CommonSpeciesName = "Kingsnake";
                        break;
                    case "6":
                        snake.Family = SnakeFamily.Colubridae;
                        snake.Venomous = false;
                        snake.CommonSpeciesName = "Corn Snake";
                        break;
                    case "7":
                        snake.Family = SnakeFamily.Elapidae;
                        snake.Venomous = true;
                        snake.CommonSpeciesName = "King Cobra";
                        break;
                    case "8":
                        snake.Family = SnakeFamily.Elapidae;
                        snake.Venomous = true;
                        snake.CommonSpeciesName = "Black Mamba";
                        break;
                    case "9":
                        snake.Family = SnakeFamily.Pythonidae;
                        snake.Venomous = false;
                        snake.CommonSpeciesName = "Green Tree Python";
                        break;
                    case "10":
                        snake.Family = SnakeFamily.Pythonidae;
                        snake.Venomous = false;
                        snake.CommonSpeciesName = "Ball Python";
                        break;
                    default:
                        Console.WriteLine("Must enter an integer betweeen 1 and 10. Try again.");
                        Console.WriteLine();
                        continue;
                }


                Console.WriteLine();
                Console.WriteLine("-----Snake Length-----");
                Console.Write("Enter snake length (cm): ");
                Console.WriteLine();
                string input = Console.ReadLine();
                decimal length;
                if (decimal.TryParse(input, out length))
                {
                    snake.LengthInCentimeters = length;
                }
                return snake;
            }
        }






        public Snake EditSnake(Snake snake)
        {

            int choice = GetSnakeEditChoice();
            if (choice == 1)//species
            {
                while (true)
                {
                    DisplaySpeciesChoices();

                    string species = Console.ReadLine();

                    switch (species)//private mthod
                    {
                        case "1":
                            snake.Family = SnakeFamily.Viperidae;
                            snake.Venomous = true;
                            snake.CommonSpeciesName = "Timber Rattlesnake";
                            break;
                        case "2":
                            snake.Family = SnakeFamily.Viperidae;
                            snake.Venomous = true;
                            snake.CommonSpeciesName = "North American Cooperhead";
                            break;
                        case "3":
                            snake.Family = SnakeFamily.Boidae;
                            snake.Venomous = false;
                            snake.CommonSpeciesName = "Boa Constrictor";
                            break;
                        case "4":
                            snake.Family = SnakeFamily.Boidae;
                            snake.Venomous = false;
                            snake.CommonSpeciesName = "Green Anaconda";
                            break;
                        case "5":
                            snake.Family = SnakeFamily.Colubridae;
                            snake.Venomous = false;
                            snake.CommonSpeciesName = "Kingsnake";
                            break;
                        case "6":
                            snake.Family = SnakeFamily.Colubridae;
                            snake.Venomous = false;
                            snake.CommonSpeciesName = "Corn Snake";
                            break;
                        case "7":
                            snake.Family = SnakeFamily.Elapidae;
                            snake.Venomous = true;
                            snake.CommonSpeciesName = "King Cobra";
                            break;
                        case "8":
                            snake.Family = SnakeFamily.Elapidae;
                            snake.Venomous = true;
                            snake.CommonSpeciesName = "Black Mamba";
                            break;
                        case "9":
                            snake.Family = SnakeFamily.Pythonidae;
                            snake.Venomous = false;
                            snake.CommonSpeciesName = "Green Tree Python";
                            break;
                        case "10":
                            snake.Family = SnakeFamily.Pythonidae;
                            snake.Venomous = false;
                            snake.CommonSpeciesName = "Ball Python";
                            break;
                        default:
                            Console.WriteLine("Must enter an integer betweeen 1 and 10. Try again.");
                            Console.WriteLine();
                            continue;
                    }
                    return snake;
                }
            }
            else if (choice == 2)
            {
                //Length
                Console.WriteLine();
                Console.WriteLine("-----Snake Length-----");
                Console.Write("Enter snake length (cm): ");
                Console.WriteLine();
                string input = Console.ReadLine();
                decimal length;
                if (decimal.TryParse(input, out length))
                {
                    snake.LengthInCentimeters = length;
                }
                return snake;

            }
            else
            {

            }
            return snake;
        }


        public void DisplaySpeciesChoices()
        {
            Console.WriteLine("Snake Species");
            Console.WriteLine();
            Console.WriteLine("Please choose one of the following species (Enter 1-10): ");
            Console.WriteLine();
            Console.WriteLine("1. Timber Rattlesnake");
            Console.WriteLine("2. North American Cooperhead");
            Console.WriteLine("3. Boa Constrictor");
            Console.WriteLine("4. Green Anaconda");
            Console.WriteLine("5. Kingsnake");
            Console.WriteLine("6. Corn Snake");
            Console.WriteLine("7. King Cobra");
            Console.WriteLine("8. Black Mamba");
            Console.WriteLine("9. Green Tree Python");
            Console.WriteLine("10. Ball Python");
            Console.WriteLine("If you do not see your snake species; I apologize, we do not service your snake.");
        }


        public void GeneralWriteLine(string prompt)
        {
            Console.WriteLine(prompt);
            Console.WriteLine();
        }


        public void WorkFlowHeader(string prompt)
        {
            Console.Clear();
            Console.WriteLine("----------" + prompt + "----------");
            Console.WriteLine();
        }


        public void DisplaySnake(Snake snake)
        {
            Console.WriteLine();
            Console.WriteLine("Snake ID#: {0}", snake.ID);
            Console.WriteLine("Species: {0}", snake.CommonSpeciesName);
            Console.WriteLine("Familia: {0}", snake.Family);
            Console.WriteLine("Length (cm): {0}", snake.LengthInCentimeters);
            Console.WriteLine("Venomous: {0}", snake.Venomous);
            Console.WriteLine();
        }


        public int SearchSnake()
        {
            while (true)
            {
                Console.Write("Please enter the snake ID#: ");
                Console.WriteLine();
                string input = Console.ReadLine();
                int IDNum;
                if (int.TryParse(input, out IDNum))
                {
                    return IDNum;
                }
                else
                {
                    Console.WriteLine("Must enter an integer. Try again.");
                    continue;
                }
            }
        }


        public bool ConfirmRemoveSnake(Snake snake)
        {
            while (true)
            {
                bool removeYes = true;
                DisplaySnake(snake);
                Console.WriteLine();
                Console.WriteLine("Confirm remove snake (Enter Y/N):");
                string input = Console.ReadLine();
                if (input == "N" || input == "n" || input == "No" || input == "no")
                {
                    removeYes = false;
                    Console.Clear();
                    return removeYes;
                }
                else if (input == "Y" || input == "y" || input == "Yes" || input == "yes")
                {
                    removeYes = true;
                    return removeYes;
                }
                else
                {
                    Console.WriteLine("Invalid entry. Try again.");
                    continue;
                }
            }

        }


        public bool ConfirmSnakeLookingFor(Snake snake)
        {
            bool correctSnake;
            while (true)
            {

                Console.WriteLine();
                Console.Write("Is this the snake you are looking for? (Enter Y/N): ");
                Console.WriteLine();
                string input = Console.ReadLine();
                if (input == "N" || input == "n" || input == "No" || input == "no")
                {
                    correctSnake = false;
                    Console.Clear();
                    return correctSnake;

                }
                else if (input == "Y" || input == "y" || input == "Yes" || input == "yes")
                {
                    correctSnake = true;
                    return correctSnake;
                }
                else
                {
                    Console.WriteLine("Invalid entry. Try again.");
                    continue;
                }
            }

        }
    }
}
