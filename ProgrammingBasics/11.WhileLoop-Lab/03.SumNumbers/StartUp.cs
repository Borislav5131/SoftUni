using System;

namespace _03.SumNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int totalSum = 0;

            while (totalSum < n)
            {
                int number = int.Parse(Console.ReadLine());
                totalSum += number;
            }

            Console.WriteLine(totalSum);
        }    
    }
}
