using System;
using System.Threading;

namespace _07.MinNumber
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int minNumber = int.MaxValue;

            while (input != "Stop")
            {
                int number = int.Parse(input);
                input = Console.ReadLine();
                if (number < minNumber)
                {
                    minNumber = number;
                }
            }

            Console.WriteLine(minNumber);
        }
    }
}
