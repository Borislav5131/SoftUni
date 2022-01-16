using System;

namespace _08.FuelTank
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string fuel = Console.ReadLine();
            double fuelLitters = double.Parse(Console.ReadLine());

            if (fuelLitters >= 25)
            {
                if (fuel == "Diesel" )
                {
                    Console.WriteLine("You have enough diesel.");
                }
                else if (fuel == "Gasoline")
                {
                    Console.WriteLine("You have enough gasoline.");
                }
                else if (fuel == "Gas")
                {
                    Console.WriteLine("You have enough gas.");
                }
                else
                {
                    Console.WriteLine("Invalid fuel!");
                }
            }
            else if (fuelLitters < 25)
            {
                if (fuel == "Diesel")
                {
                    Console.WriteLine("Fill your tank with diesel!");
                }
                else if (fuel == "Gasoline")
                {
                    Console.WriteLine("Fill your tank with gasoline!");
                }
                else if (fuel == "Gas")
                {
                    Console.WriteLine("Fill your tank with gas!");
                }
                else
                {
                    Console.WriteLine("Invalid fuel!");
                }
            }
        }
    }
}
