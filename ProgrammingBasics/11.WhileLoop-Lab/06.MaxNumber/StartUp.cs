using System;

namespace _06.MaxNumber
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int maxNumber = int.MinValue;
            int number = 0;
            while (input != "Stop")
            {
                number = int.Parse(input);
                input = Console.ReadLine();
                if (number > maxNumber)
                {
                    maxNumber = number;
                }
            }

            Console.WriteLine(maxNumber);
        }
    }
}
