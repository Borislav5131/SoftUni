using System;
using System.Linq;

namespace _03.Zig_ZagArrays
{
    class Startup
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] firstArray = new int[n];
            int[] secondArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (i % 2 == 0)
                {
                    firstArray[i] = numbers[numbers.Length - 2];
                    secondArray[i] = numbers[numbers.Length - 1];
                }
                else
                {
                    firstArray[i] = numbers[numbers.Length - 1];
                    secondArray[i] = numbers[numbers.Length - 2];
                }

            }

            Console.WriteLine(string.Join(" ", firstArray));
            Console.WriteLine(string.Join(" ", secondArray));
        }
    }
}
