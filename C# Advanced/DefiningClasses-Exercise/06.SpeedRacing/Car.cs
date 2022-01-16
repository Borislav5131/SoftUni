using System;
using System.Collections.Generic;
using System.Text;

namespace _06.SpeedRacing
{
    public class Car
    {
        public string Model { get; set; }
        public double Fuel { get; set; }
        public double Comsumption { get; set; }
        public double Distance { get; set; }

        public Car(string model, double fuel,double comsumption)
        {
            Model = model;
            Fuel = fuel;
            Comsumption = comsumption;
            Distance = 0;
        }

        public void Drive(double kilometers)
        {
            if (Fuel >= kilometers*Comsumption)
            {
                Fuel -= kilometers * Comsumption;
                Distance += kilometers;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
