using System;

namespace _08.CircleAreaAndPerimeter
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double radius = double.Parse(Console.ReadLine());

            double calculatedArea = Math.PI * radius * radius;
            double calculatedPerimeter = 2 * Math.PI * radius;

            Console.WriteLine($"{calculatedArea:f2}");
            Console.WriteLine($"{calculatedPerimeter:f2}");
        }
    }
}
