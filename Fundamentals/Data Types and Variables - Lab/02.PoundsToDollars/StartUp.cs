using System;

namespace _02.PoundsToDollars
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double pounds = double.Parse(Console.ReadLine());

            double cours = 1.31;
            double dollars = pounds * cours;

            Console.WriteLine($"{(decimal)dollars:f3}");
        }
    }
}
