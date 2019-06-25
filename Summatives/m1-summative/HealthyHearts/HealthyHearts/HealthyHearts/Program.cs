using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyHearts
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What is your age? ");
            string input = Console.ReadLine();
            int age;
            if(int.TryParse(input, out age))
            {
            }


            int maxHeartRate = 220 - age;
            double targetHRLow = maxHeartRate * .50;
            double targetHRHigh = maxHeartRate * .85;

            Console.WriteLine("Your maximum heart rate should be {0} beats per minute.", maxHeartRate);
            Console.WriteLine("Your target HR Zone is {0} - {1} beats per minute", targetHRLow, targetHRHigh);
            Console.ReadLine();
        }
    }
}
