using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SpeedRacing
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
                Car car = new Car(tokens[0],double.Parse(tokens[1]),double.Parse(tokens[2]));
                cars.Add(car);
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "End")
                {
                    break;
                }
                else
                {
                    string model = command[1];
                    int distance = int.Parse(command[2]);

                    Car neededCar = cars
                        .Where(x => x.Model == model)
                        .ToList()
                        .First();

                    neededCar.Drive(distance);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.Fuel:f2} {car.Distance}");
            }

        }
    }
}
