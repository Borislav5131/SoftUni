using System;
using System.Xml;

namespace _02.TriangleArea
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double sideA = double.Parse(Console.ReadLine());
            double heightH = double.Parse(Console.ReadLine());

            double areaOfTriangle = (sideA * heightH) / 2;

            Console.WriteLine($"{areaOfTriangle:f2}");
        }
    }
}
