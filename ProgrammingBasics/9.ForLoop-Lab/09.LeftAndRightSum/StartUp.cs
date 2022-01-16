using System;

namespace _09.LeftAndRightSum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int leftNumber = 0;
            int rightNumber = 0;

            for (int i = 1; i <= count; i++)
            {
                int number = int.Parse(Console.ReadLine());
                leftNumber += number;
            }
            for (int i = 1; i <= count; i++)
            {
                int number = int.Parse(Console.ReadLine());
                rightNumber += number;
            }

            if (leftNumber == rightNumber)
            {
                Console.WriteLine($"Yes, sum = {leftNumber}");
            }
            else if (leftNumber != rightNumber)
            {
                int diff = Math.Abs(leftNumber - rightNumber);
                Console.WriteLine($"No, diff = {diff}");
            }
        }
    }
}
