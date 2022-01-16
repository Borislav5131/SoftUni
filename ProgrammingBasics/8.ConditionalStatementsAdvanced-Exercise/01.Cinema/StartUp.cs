using System;

namespace _01.Cinema
{
    class StartUp
    {
        static void Main(string[] args)
        {
            const double premiereTicket = 12.00;
            const double normarTicket = 7.50;
            const double discountticket = 5.00;

            string typeProjection = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            double sumOfticket = 0;

            switch (typeProjection)
            {
                case "Premiere":
                    sumOfticket = premiereTicket;
                    break;
                case "Normal":
                    sumOfticket = normarTicket;
                    break;
                case "Discount":
                    sumOfticket = discountticket;
                    break;
            }

            double totalSum = rows * columns * sumOfticket;
            Console.WriteLine($"{totalSum:f2} leva");
        }
    }
}
