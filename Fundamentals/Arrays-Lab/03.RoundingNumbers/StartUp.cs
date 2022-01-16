using System;
using System.Linq;

namespace _03.RoundingNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            decimal[] roundingNumbers = new decimal[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                roundingNumbers[i] = (decimal)Math.Round(numbers[i], MidpointRounding.AwayFromZero);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"{(decimal)numbers[i]} => {(decimal)roundingNumbers[i]}");
            }
        }
    }
}
