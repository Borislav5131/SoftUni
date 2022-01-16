using System;

namespace _05.Journey
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double sum = 0;

            if (budget <= 100)
            {
                //In Bulgaria
                switch (season)
                {
                    case "summer":
                        sum = budget * 0.30;
                        Console.WriteLine($"Somewhere in Bulgaria");
                        Console.WriteLine($"Camp - {sum:f2}");
                        break;
                    case "winter":
                        sum = budget * 0.70;
                        Console.WriteLine($"Somewhere in Bulgaria");
                        Console.WriteLine($"Hotel - {sum:f2}");
                        break;
                }
            }
            else if (budget <= 1000)
            {
                // In Balkans
                switch (season)
                {
                    case "summer":
                        sum = budget * 0.40;
                        Console.WriteLine($"Somewhere in Balkans");
                        Console.WriteLine($"Camp - {sum:f2}");
                        break;
                    case "winter":
                        sum = budget * 0.80;
                        Console.WriteLine($"Somewhere in Balkans");
                        Console.WriteLine($"Hotel - {sum:f2}");
                        break;
                }
            }
            else if (budget > 1000)
            {
                // In Europe
                sum = budget * 0.90;
                Console.WriteLine($"Somewhere in Europe");
                Console.WriteLine($"Hotel - {sum:f2}");
            };
        }
    }
}
