namespace _01.Vehicles
{
    using System;
    public class Truck : Vehicle
    {
        private const double airConditionConsumption = 1.6;
        public Truck(double quantity, double consumption, double tankCapacity) 
            : base(quantity, consumption, tankCapacity)
        {

        }

        public override double Consumption => base.Consumption + airConditionConsumption;

        public override void Refuel(double litters)
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
                Quantity += litters * 0.95;
            }
        }
    }
}
