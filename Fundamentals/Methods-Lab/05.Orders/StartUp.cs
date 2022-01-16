using System;

namespace _05.Orders
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            ProductPrice(product, count);
        }
        static void ProductPrice(string product, int count)
        {
            double coffePrice = 1.50;
            double waterPrice = 1.00;
            double cokePrice = 1.40;
            double snacksPrice = 2.00;

            double sum = 0;

            if (product == "coffee")
            {
                sum = count * coffePrice;
            }
            else if (product == "water")
            {
                sum = count * waterPrice; ;
            }
            else if (product == "coke")
            {
                sum = count * cokePrice; ;
            }
            else if (product == "snacks")
            {
                sum = count * snacksPrice; ;
            }

            Console.WriteLine($"{sum:f2}");
        }
    }
}
