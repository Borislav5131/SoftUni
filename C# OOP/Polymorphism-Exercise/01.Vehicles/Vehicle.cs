using System;

namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        public double Quantity { get; set; }
        public virtual double Consumption { get; private set; }
        public double TankCapacity { get; private set; }


        public Vehicle(double quantity, double consumption,double tankCapacity)
        {
            if (quantity > tankCapacity)
            {
                Quantity = 0;
            }
            else
            {
                Quantity = quantity;
            }

            TankCapacity = tankCapacity;
            Consumption = consumption;
        }

        public void Drive(double distance)
        {
            bool canDrive = Quantity - (distance * Consumption) > 0;

            if (canDrive)
            {
                Quantity -= distance * Consumption;
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double litters)
        {
            if (litters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }

            if (Quantity + litters > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {litters} fuel in the tank");
            }
            else
            {
                Quantity += litters;
            }
        }
    }
}
