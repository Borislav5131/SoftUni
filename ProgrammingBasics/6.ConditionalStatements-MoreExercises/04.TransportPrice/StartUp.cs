using System;

namespace _04.TransportPrice
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double numberOfKilometers = double.Parse(Console.ReadLine());
            string text = Console.ReadLine();

            if (numberOfKilometers < 20)
            {
                if (text == "day")
                {
                    double totalSum = 0.70 + numberOfKilometers * 0.79;
                    Console.WriteLine($"{totalSum:f2}");
                }
                else if (text == "night")
                {
                    double totalSum = 0.70 + numberOfKilometers * 0.90;
                    Console.WriteLine($"{totalSum:f2}");
                }
            }
            else if (numberOfKilometers >= 20 && numberOfKilometers < 100)
            {
                double totalSum = 0.09 * numberOfKilometers;
                Console.WriteLine($"{totalSum:f2}");
            }
            else if (numberOfKilometers >= 100)
            {
                double totalSum = 0.06 * numberOfKilometers;
                Console.WriteLine($"{totalSum:f2}");
            }
        }
    }
}
