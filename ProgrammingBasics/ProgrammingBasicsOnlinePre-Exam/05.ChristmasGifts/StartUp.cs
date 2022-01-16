using System;

namespace _05.ChristmasGifts
{
    class Startup
    {
        static void Main(string[] args)
        {
            const double toysPrice = 5;
            const double sweatersPrice = 15;

            string input = Console.ReadLine();

            int numberOfAdults = 0;
            int numberOfKids = 0;
            double moneyForToys = 0;
            double moneyForSweaters = 0;

            while (input != "Christmas")
            {
                int age = int.Parse(input);

                if (age <= 16)
                {
                    numberOfKids++;
                    moneyForToys += toysPrice;
                }
                else if (age > 16)
                {
                    numberOfAdults++;
                    moneyForSweaters += sweatersPrice;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"Number of adults: {numberOfAdults}");
            Console.WriteLine($"Number of kids: {numberOfKids}");
            Console.WriteLine($"Money for toys: {moneyForToys}");
            Console.WriteLine($"Money for sweaters: {moneyForSweaters}");
        }
    }
}
