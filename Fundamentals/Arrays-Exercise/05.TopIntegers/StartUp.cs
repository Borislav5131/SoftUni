using System;
using System.Linq;

namespace _05.TopIntegers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                bool isTopNumber = true;

                for (int j = i + 1; j < numbers.Length; j++)
                {

                    if (numbers[i] <= numbers[j])
                    {
                        isTopNumber = false;
                    }
                }

                if (isTopNumber)
                {
                    Console.Write($"{numbers[i]} ");
                }
            }
        }
    }
}
