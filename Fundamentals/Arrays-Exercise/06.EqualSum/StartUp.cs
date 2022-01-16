using System;
using System.Linq;

namespace _06.EqualSum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            bool flag = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                flag = false;
                if (numbers.Length == 1)
                {
                    Console.WriteLine(0);
                }

                int leftSum = 0;
                int rightSum = 0;

                for (int j = 0; j < i; j++)
                {
                    leftSum += numbers[j];
                }

                for (int k = 1 + i; k < numbers.Length; k++)
                {
                    rightSum += numbers[k];
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    break;
                }
                else
                {
                    flag = true;
                }
            }

            if (flag)
            {
                Console.WriteLine("no");
            }
        }
    }
}
