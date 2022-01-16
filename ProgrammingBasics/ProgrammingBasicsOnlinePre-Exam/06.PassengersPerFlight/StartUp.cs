using System;

namespace _06.PassengersPerFlight
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfAirlines = int.Parse(Console.ReadLine());

            double passangers = 0;
            int counter = 0;
            double avgPassangers = 0;
            double maxAvgPassangers = double.MinValue;
            string airlineWithMaxPassanger = "";

            for (int i = 1; i <= numberOfAirlines; i++)
            {
                string text = Console.ReadLine();
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "Finish")
                    {
                        break;
                    }
                    int numberOfPassangers = int.Parse(input);

                    counter += 1;
                    passangers += numberOfPassangers;
                    continue;
                }
                avgPassangers = Math.Floor(passangers / counter);

                Console.WriteLine($"{text}: {avgPassangers} passengers.");

                if (avgPassangers > maxAvgPassangers)
                {
                    maxAvgPassangers = avgPassangers;
                    airlineWithMaxPassanger = text;
                }

                passangers = 0;
                counter = 0;
                avgPassangers = 0;
            }

            Console.WriteLine($"{airlineWithMaxPassanger} has most passengers per flight: {maxAvgPassangers}");
        }
    }
}
