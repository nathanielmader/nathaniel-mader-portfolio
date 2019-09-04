using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class GameFlow
    {
        private int _roundsToPlay;
        private int _playerChoice;
        int compWins = 0;
        int userWins = 0;
        int tieDraw = 0;
        int roundCount = 1;
        bool gameOn = true;

        public void Run()
        {
            TitleScreen();
            GetNumberOfRounds();
            Play();
            DisplayResults();
            GetPlayAgain();
        }

        public void TitleScreen()
        {
            Console.WriteLine("----------Welcome to Rock Paper Scissors----------");
            Console.WriteLine();
        }
        public void GetNumberOfRounds()
        {
            while (true)
            {
                Console.WriteLine("How many rounds would you like to play (Min = 1, Max = 10)?: ");
                string input = Console.ReadLine();
                int roundsToPlay = 0;
                if (int.TryParse(input, out roundsToPlay) && roundsToPlay >= 1 && roundsToPlay <= 10)
                {
                    _roundsToPlay = roundsToPlay;
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Entry.");
                    Console.WriteLine();
                    continue;
                }
            }
        }
        public int GetPlayerChoice()//Returns players RPS choice
        {
            while (true)
            {
                Console.WriteLine("-----ROUND {0}-----", roundCount);
                Console.WriteLine();
                Console.Write("Please enter your choice. 1 = Rock, 2 = Paper, 3 = Scissors: ");
                string input = Console.ReadLine();
                int playerChoice;
                if (int.TryParse(input, out playerChoice) && playerChoice >= 1 && playerChoice <= 3)
                {
                    _playerChoice = playerChoice;
                    return playerChoice;
                }
                else
                {
                    Console.WriteLine("Invalid Entry.");
                    continue;
                }
            }

        }

        public void Play()
        {
            while (roundCount <= _roundsToPlay)
            {
                int pChoice = GetPlayerChoice();
                Random random = new Random();
                int compChoice = random.Next(1, 4);
                if ((pChoice == 1 && compChoice == 3) || (pChoice == 2 && compChoice == 1) || (pChoice == 3 && compChoice == 2))
                {

                    Console.WriteLine("Round Result: You Win!", roundCount);
                    Console.WriteLine();
                    Console.WriteLine();
                    userWins++;
                    roundCount++;
                }
                else if (pChoice == compChoice)
                {
                    Console.WriteLine("Round Result: Draw", roundCount);
                    Console.WriteLine();
                    Console.WriteLine();
                    tieDraw++;
                    roundCount++;
                }
                else
                {
                    Console.WriteLine("Round Result: Computer Wins", roundCount);
                    Console.WriteLine();
                    Console.WriteLine();
                    compWins++;
                    roundCount++;
                }
            }
        }

        public void DisplayResults()
        {
            if ((userWins > compWins) && (userWins > tieDraw))
            {
                DisplayRound(" You Win!!");
            }
            else if ((userWins < compWins) && (compWins > tieDraw))
            {
                DisplayRound(" Computer Wins  :(");
            }
            else
            {
                DisplayRound(" Tie Game...Lame.");
            }
            Console.WriteLine();
        }

        public void GetPlayAgain()
        {
            while (true)
            {
                Console.Write("Would you like to play again? (Enter Y/N): ");
                string input = Console.ReadLine();

                if (input == "Y" || input == "y" || input == "Yes" || input == "yes")
                {
                    Console.Clear();
                    Run();
                    break;
                }
                else if (input == "N" || input == "n" || input == "No" || input == "no")
                {
                    Console.WriteLine();
                    Console.WriteLine("Thanks for playing!");
                    Console.WriteLine("Press any key to quit.");
                    Console.WriteLine();
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Entry.");
                    Console.WriteLine();
                    continue;
                }
            }
        }
        public void DisplayRound(string prompt)
        {
            Console.WriteLine();
            Console.WriteLine("----------Game Results----------");
            Console.WriteLine("User Wins: {0}", userWins);
            Console.WriteLine("Computer Wins: {0}", compWins);
            Console.WriteLine("Ties/Draws: {0}", tieDraw);
            Console.WriteLine();
            Console.WriteLine("OVERALL RESULT:" + prompt);
            Console.WriteLine();
        }
    }
}
