using System;

namespace _07.HousePainting
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double sideX = double.Parse(Console.ReadLine());
            double sideY = double.Parse(Console.ReadLine());
            double sideH = double.Parse(Console.ReadLine());

            //sides
            double sideOfHouse = sideX * sideY;
            double window = 1.5 * 1.5;
            double twoSides = 2 * sideOfHouse - 2 * window;
            double rearSide = sideX * sideX;
            double enter = 1.2 * 2;
            double backAndFrontSides = 2 * rearSide - enter;
            double areaOfHouse = twoSides + backAndFrontSides;
            double greenPaint = areaOfHouse / 3.4;

            //roof
            double rectangularOnRoof = 2 * (sideX * sideY);
            double trianularOnRoof = 2 * (sideX * sideH / 2);
            double areaOfRoof = rectangularOnRoof + trianularOnRoof;
            double redPaint = areaOfRoof / 4.3;

            Console.WriteLine($"{greenPaint:f2}");
            Console.WriteLine($"{redPaint:f2}");
        }
    }
}
