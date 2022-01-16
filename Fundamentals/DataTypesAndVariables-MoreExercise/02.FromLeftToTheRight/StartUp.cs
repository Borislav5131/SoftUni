using System;
using System.Linq;

namespace _02.FromLeftToTheRight
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            for (int i = 1; i <= n; i++)
            {
                long[] numbers = Console.ReadLine()
                    .Split(" ")
                    .Select(long.Parse)
                    .ToArray();

                long sumOfDigits = 0;

                if (numbers[0] >= numbers[1])
                {
                    while (numbers[0] > 0)
                    {
                        long lastDigit = numbers[0] % 10;
                        numbers[0] /= 10;

                        sumOfDigits += lastDigit;
                    }
                }
                else
                {
                    while (numbers[1] > 0)
                    {
                        long lastDigit = numbers[1] % 10;
                        numbers[1] /= 10;

                        sumOfDigits += lastDigit;
                    }
                }

                Console.WriteLine(sumOfDigits);
            }
        }
    }
}
