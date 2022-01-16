using System;

namespace _04.PrintingTriangle
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            PrintTriangel(number);
        }
        static void PrintLine(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
        static void PrintTriangel(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                PrintLine(i);
            }
            for (int i = number - 1; i >= 1; i--)
            {
                PrintLine(i);
            }
        }
    }
}
