using System;

namespace SimpleOperationsAndCalculations_More_Exercises
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double sideA = double.Parse(Console.ReadLine());
            double sideB = double.Parse(Console.ReadLine());
            double heightH = double.Parse(Console.ReadLine());

            double areaOfTrapeze = ((sideA + sideB) * heightH) / 2;

            Console.WriteLine($"{areaOfTrapeze:f2}");
        }
    }
}
