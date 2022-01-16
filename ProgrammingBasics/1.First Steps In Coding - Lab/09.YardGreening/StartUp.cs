using System;

namespace _09.YardGreening
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double squareMeters = double.Parse(Console.ReadLine());

            double priceForOneSquareMeter = 7.61;
            double discount = 0.18 ;

            double priceForGreening = squareMeters * priceForOneSquareMeter;
            double sumWithDiscount = discount * priceForGreening;
            double finalPrice = priceForGreening - sumWithDiscount;

            Console.WriteLine($"The final price is: {finalPrice}");
            Console.WriteLine($"The discount is: {sumWithDiscount}");
        }
    }
}
