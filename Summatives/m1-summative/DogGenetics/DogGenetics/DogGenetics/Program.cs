using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogGenetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What is your dog's name? ");
            string name = Console.ReadLine();
            Console.WriteLine("Well then, I have this highly reliable report on {0}'s prestigious background right here.", name);
            Console.WriteLine();
            Console.WriteLine("{0} is:", name);
            Console.WriteLine();

            string[] dogList = new string[] { "St. Bernard", "Chihuahua", "Dramatic RedNosed Asian Pug", "Common Cur", "King Doberman" };
            Random rnd = new Random();
            int[] numbers = new int[5];
            for (int i = 0; i < 100; i++)
            {
                int dogBreed = rnd.Next(5);
                numbers[dogBreed] = numbers[dogBreed] + 1;
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("{0}% {1}", numbers[i], dogList[i]);
            }
            Console.ReadLine();
            Console.WriteLine("Wow, that's QUITE the dog!");

        }
    }
}
