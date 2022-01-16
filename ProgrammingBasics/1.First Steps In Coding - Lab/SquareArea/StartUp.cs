using System;

namespace SquareArea
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int side = int.Parse(Console.ReadLine());

            int areaOfSquare = side * side;

            Console.WriteLine(areaOfSquare);
        }
    }
}
