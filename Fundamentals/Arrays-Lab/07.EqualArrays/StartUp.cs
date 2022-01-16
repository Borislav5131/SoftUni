using System;
using System.Linq;

namespace _07.EqualArrays
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] array1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] array2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            bool isIdentical = true;
            int sum = 0;
            int differentIndex = 0;
            int counter = 0;

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] == array2[i])
                {
                    sum += array1[i];
                }
                else
                {
                    isIdentical = false;
                    break;
                }

                counter++;
            }

            if (!isIdentical)
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {counter} index");
            }
            else
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
        }
    }
}
