using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _07.RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                Engine carEngine = new Engine(int.Parse(tokens[1]), int.Parse(tokens[2]));
                Cargo carCargo = new Cargo(int.Parse(tokens[3]), tokens[4]);
                List<Tire> carTires = new List<Tire>()
                {
                    new Tire(double.Parse(tokens[5]),int.Parse(tokens[6])),
                    new Tire(double.Parse(tokens[7]),int.Parse(tokens[8])),
                    new Tire(double.Parse(tokens[9]),int.Parse(tokens[10])),
                    new Tire(double.Parse(tokens[11]),int.Parse(tokens[12])),
                };
                Car car = new Car(tokens[0], carEngine,carCargo,carTires);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                cars = cars
                    .Where(x=>x.Cargo.Type == command && x.Tires.Any(x => x.Pressure < 1))
                    .ToList();

                foreach (var car in cars)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command == "flamable")
            {
                cars = cars
                    .Where(x => x.Cargo.Type == command && x.Engine.Power > 250)
                    .ToList();

                foreach (var car in cars)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
