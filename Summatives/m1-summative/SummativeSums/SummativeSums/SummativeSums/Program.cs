using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummativeSums
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] one = new int[] { 1, 90, -33, -55, 67, -16, 28, -55, 15 };
            int[] two = new int[] { 999, -60, -77, 14, 160, 301 };
            int[] three = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200, -99 };

            //int uno = SumArray(one);
            //int dos = SumArray(two);
            //int tres = SumArray(three);

            Console.WriteLine("#1 Array Sum: {0}", SumArray(one));
            Console.WriteLine("#2 Array Sum: {0}", SumArray(two));
            Console.WriteLine("#3 Array Sum: {0}", SumArray(three));
            Console.ReadLine();
        }

        private static int SumArray(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }
    }
}
