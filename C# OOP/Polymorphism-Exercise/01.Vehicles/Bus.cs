using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;

namespace _01.Vehicles
{
   public class Bus : Vehicle
   {
       private const double airConditionsConsumption = 1.4;
        public Bus(double quantity, double consumption, double tankCapacity)
            : base(quantity, consumption, tankCapacity)
        {
        }

        public bool IsEmpty { get; set; } = false;

        public override double Consumption => IsEmpty
            ? base.Consumption
            : base.Consumption + airConditionsConsumption;
   }
}
