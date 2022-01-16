using System;

namespace _06.AreaOfFigures
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            if (figure == "square")
            {
                double sideA = double.Parse(Console.ReadLine());
                double area = sideA * sideA;
                Console.WriteLine($"{area:f3}");
            }
            else if (figure == "rectangle")
            {
                double sideA = double.Parse(Console.ReadLine());
                double sideB = double.Parse(Console.ReadLine());
                double area = sideA * sideB;
                Console.WriteLine($"{area:f3}");
            }
            else if (figure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                double area = Math.PI * (radius * radius);
                Console.WriteLine($"{area:f3}");
            }
            else if (figure == "triangle")
            {
                double sideA = double.Parse(Console.ReadLine());
                double heightH = double.Parse(Console.ReadLine());
                double area = (sideA * heightH) / 2;
                Console.WriteLine($"{area:f3}");
            }
        }
    }
}
