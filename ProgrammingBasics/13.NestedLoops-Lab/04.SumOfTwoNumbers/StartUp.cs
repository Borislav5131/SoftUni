using System;
using System.Diagnostics.Tracing;

namespace _04.SumOfTwoNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int finish = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());

            bool isFound = false;
            int counter = 0;

            for (int i = start; i <= finish; i++)
            {
                for (int k = start; k <= finish; k++)
                {
                    counter++;
                    if (i + k == magicNum)
                    {
                        isFound = true;
                        Console.WriteLine($"Combination N:{counter} ({i} + {k} = {magicNum})");
                        break;
                    }
                }
                if (isFound)
                {
                    break;
                }
            }
            if (!isFound)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicNum}");
            }
        }
    }
}
