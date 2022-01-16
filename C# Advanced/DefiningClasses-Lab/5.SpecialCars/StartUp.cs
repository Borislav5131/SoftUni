using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "No more tires")
                {
                    break;
                }
                else
                {
                    double[] tokens = command.Split().Select(double.Parse).ToArray();

                    var currTire = new Tire[4]
                    {
                        new Tire((int) tokens[0], tokens[1]),
                        new Tire((int) tokens[2], tokens[3]),
                        new Tire((int) tokens[4], tokens[5]),
                        new Tire((int) tokens[6], tokens[7])
                    };

                    tires.Add(currTire);
                }
            }

            List<Engine> engines = new List<Engine>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Engines done")
                {
                    break;
                }
                else
                {
                    double[] tokens = command.Split().Select(double.Parse).ToArray();

                    for (int i = 0; i < tokens.Length - 1; i++)
                    {
                        Engine engine = new Engine((int)tokens[i], tokens[i + 1]);
                        engines.Add(engine);
                    }
                }
            }

            List<Car> cars = new List<Car>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Show special")
                {
                    break;
                }
                else
                {
                    string[] tokens = command.Split();

                    var make = tokens[0];
                    var model = tokens[1];
                    var year = int.Parse(tokens[2]);
                    var fuelQuantity = double.Parse(tokens[3]);
                    var fuelCapacity = double.Parse(tokens[4]);
                    var engineIndex = int.Parse(tokens[5]);
                    var tireIndex = int.Parse(tokens[6]);

                    if ((engineIndex >= 0 && engineIndex < engines.Count) &&
                        (tireIndex >= 0 && tireIndex < tires.Count))
                    {
                        Car car = new Car(make, model, year, fuelQuantity, fuelCapacity, engines[engineIndex],
                            tires[tireIndex]);
                        cars.Add(car);
                    }
                }
            }

            var specialCars = cars.Where(x => x.Year >= 2017 && x.Engine.HorsePower > 330 && x.Tires.Sum(y => y.Pressure) >= 9 && x.Tires.Sum(y => y.Pressure) <= 10).ToList();

            if (cars.Any())
            {
                foreach (var car in specialCars)
                {
                    car.Drive(20);
                    Console.WriteLine(car.WhoAmI());
                }
            }
        }
    }
}