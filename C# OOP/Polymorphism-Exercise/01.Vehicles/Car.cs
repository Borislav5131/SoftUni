namespace _01.Vehicles
{
    public class Car : Vehicle
    {
        private const double airConditionConsumption = 0.9;
        public Car(double quantity, double consumption,double tankCapacity) 
            : base(quantity, consumption, tankCapacity)
        {

        }

        public override double Consumption => base.Consumption + airConditionConsumption;
    }
}
