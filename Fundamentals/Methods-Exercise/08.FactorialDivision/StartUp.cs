using System;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            long result = FirstFactorialSum(num1) / SecondFactorialSum(num2);

            Console.WriteLine($"{result:f2}");
        }

        static long FirstFactorialSum(int num1)
        {
            long factorial = 1;

            for (int i = 1; i <= num1; i++)
            {
                factorial = factorial * i;
            }

            return factorial;
        }
        static long SecondFactorialSum(int num2)
        {
            long factorial = 1;

            for (int i = 1; i <= num2; i++)
            {
                factorial = factorial * i;
            }

            return factorial;
        }

    }
}
