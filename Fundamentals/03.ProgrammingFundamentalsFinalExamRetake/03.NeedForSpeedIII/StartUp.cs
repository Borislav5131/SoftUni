using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NeedForSpeedIII
{
    class Car
    {
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 1; i <= n; i++)
            {
                string[] input = Console.ReadLine().Split("|");
                string car = input[0];
                int mileage = int.Parse(input[1]);
                int fuel = int.Parse(input[2]);

                cars.Add(car, new Car());
                cars[car].Mileage = mileage;
                cars[car].Fuel = fuel;
            }

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(" : ");
                string command = tokens[0];
                

                if (command == "Stop")
                {
                    break;
                }
                else if (command == "Drive")
                {
                    string car = tokens[1];
                    int distance = int.Parse(tokens[2]);
                    int fuel = int.Parse(tokens[3]);

                    if (cars[car].Fuel >= fuel)
                    {
                        cars[car].Mileage += distance;
                        cars[car].Fuel -= fuel;

                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }
                    else
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }

                    if (cars[car].Mileage >= 100000)
                    {
                        cars.Remove(car);

                        Console.WriteLine($"Time to sell the {car}!");
                    }

                }
                else if (command == "Refuel")
                {
                    string car = tokens[1];
                    int fuel = int.Parse(tokens[2]);

                    int oldFuel = cars[car].Fuel;
                    cars[car].Fuel += fuel;

                    if (cars[car].Fuel > 75)
                    {
                        cars[car].Fuel -= cars[car].Fuel - 75;
                        fuel = cars[car].Fuel - oldFuel;
                    }

                    Console.WriteLine($"{car} refueled with {fuel} liters");
                }
                else if (command == "Revert")
                {
                    string car = tokens[1];
                    int kilometers = int.Parse(tokens[2]);

                    cars[car].Mileage -= kilometers;

                    if (cars[car].Mileage <= 10000)
                    {
                        cars[car].Mileage = 10000;
                        continue;
                    }

                    Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");

                }
            }

            cars = cars
                .OrderByDescending(x => x.Value.Mileage)
                .ThenBy(x => x.Key)
                .ToDictionary(x=>x.Key, x=>x.Value);

            foreach (var kvp in cars)
            {
                Console.WriteLine($"{kvp.Key} -> Mileage: {kvp.Value.Mileage} kms, Fuel in the tank: {kvp.Value.Fuel} lt.");
            }
        }
    }
}
