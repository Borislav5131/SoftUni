using System;
using System.Diagnostics.CodeAnalysis;

namespace _08.FuelTank_Part2
{
    class StartUp
    {
        static void Main(string[] args)
        {
             double dieselPrice = 2.33;
             double gasolinePrice = 2.22;
             double gasPrice = 0.93;

            string fuelType = Console.ReadLine();
            double countOfFuel = double.Parse(Console.ReadLine());
            string clubCard = Console.ReadLine();


            if (clubCard == "Yes")
            {
                dieselPrice -= 0.12;
                gasolinePrice -= 0.18;
                gasPrice -= 0.08;
            }

            double sum = 0;

            if (fuelType == "Diesel")
            {
                sum += countOfFuel * dieselPrice;
            }
            else if (fuelType == "Gasoline")
            {
                 sum += countOfFuel * gasolinePrice;
            }
            else if (fuelType == "Gas")
            {
                sum += countOfFuel * gasPrice;
            }


            if (countOfFuel >= 20 && countOfFuel <= 25)
            {
                double discount = sum * 0.08;
                sum -= discount;
            }
            else if (countOfFuel > 25)
            {
                double discount = sum * 0.1;
                sum -= discount;
            }

            Console.WriteLine($"{sum:f2} lv.");
        }
    }
}
