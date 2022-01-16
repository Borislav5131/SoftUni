using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.VehicleCatalogue
{
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }
    class Catalog
    {
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }

        public Catalog()
        {
            Cars = new List<Car>();
            Trucks = new List<Truck>();
        }
    }

    class StartUp
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] tokens = input.Split("/", StringSplitOptions.RemoveEmptyEntries);

                string type = tokens[0];

                if (type == "Car")
                {
                    Car car = new Car();

                    car.Brand = tokens[1];
                    car.Model = tokens[2];
                    car.HorsePower = int.Parse(tokens[3]);

                    catalog.Cars.Add(car);
                }
                else if (type == "Truck")
                {
                    Truck truck = new Truck();

                    truck.Brand = tokens[1];
                    truck.Model = tokens[2];
                    truck.Weight = int.Parse(tokens[3]);

                    catalog.Trucks.Add(truck);
                }

            }

            List<Car> orderedListCar = catalog.Cars.OrderBy(x => x.Brand).ToList();
            List<Truck> orderedListTruck = catalog.Trucks.OrderBy(x => x.Brand).ToList();

            Console.WriteLine("Cars:");
            foreach (Car car in orderedListCar)
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }

            Console.WriteLine("Trucks:");
            foreach (Truck truck in orderedListTruck)
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
        }
    }
}
