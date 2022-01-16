using System;

namespace _10.WeatherForecast_Part_2
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double tempriture = double.Parse(Console.ReadLine());

            if (tempriture >= 26.00 && tempriture <= 35.00)
            {
                Console.WriteLine("Hot");
            }
            else if (tempriture >= 20.1 && tempriture <= 25.9)
            {
                Console.WriteLine("Warm");
            }
            else if (tempriture >= 15.00 && tempriture <= 20.00)
            {
                Console.WriteLine("Mild");
            }
            else if (tempriture >= 12.00 && tempriture <= 14.9)
            {
                Console.WriteLine("Cool");
            }
            else if (tempriture >= 5.00 && tempriture <= 11.9)
            {
                Console.WriteLine("Cold");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
