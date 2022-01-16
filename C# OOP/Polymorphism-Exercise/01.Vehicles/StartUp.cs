using System;

namespace _01.Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carTokens = Console.ReadLine().Split();
            string[] truckTokens = Console.ReadLine().Split();
            string[] busTokens = Console.ReadLine().Split();

            Car car = new Car(double.Parse(carTokens[1]),double.Parse(carTokens[2]),double.Parse(carTokens[3]));
            Truck truck = new Truck(double.Parse(truckTokens[1]), double.Parse(truckTokens[2]),double.Parse(truckTokens[3]));
            Bus bus = new Bus(double.Parse(busTokens[1]), double.Parse(busTokens[2]), double.Parse(busTokens[3]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string command = tokens[0];
                string type = tokens[1];
                double veriable = double.Parse(tokens[2]);

                if (command == "Drive")
                {
                    if (type == "Car")
                    {
                        car.Drive(veriable);
                    }
                    else if (type == "Truck")
                    {
                        truck.Drive(veriable);
                    }
                    else if (type == "Bus")
                    {
                        bus.Drive(veriable);
                    }
                }
                else if (command == "Refuel")
                {
                    if (type == "Car")
                    {
                        car.Refuel(veriable);
                    }
                    else if (type == "Truck")
                    {
                        truck.Refuel(veriable);
                    }
                    else if (type == "Bus")
                    {
                        bus.Refuel(veriable);
                    }
                }
                else if (command == "DriveEmpty")
                {
                    bus.IsEmpty = true;
                    bus.Drive(veriable);
                }
            }

            Console.WriteLine($"Car: {car.Quantity:f2}");
            Console.WriteLine($"Truck: {truck.Quantity:f2}");
            Console.WriteLine($"Bus: {bus.Quantity:f2}");
        }
    }
}
