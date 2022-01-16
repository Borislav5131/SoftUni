using System;

namespace _07.NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            PrintVertically(num);
        }
        static void PrintHorizontally(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                Console.Write($"{num} ");
            }
        }
        static void PrintVertically(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                PrintHorizontally(num);
                Console.WriteLine();
            }
        }
    }
}
