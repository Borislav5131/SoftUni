using _04.WildFarm.Interfaces;

namespace _04.WildFarm.AnimalClasses.Birds
{
    public class Hen : Bird
    {
        public override string Name { get; set; }
        public override double Weight { get; set; }
        public override int FoodEaten { get; set; }
        public override double WingSize { get; set; }

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void EatFood(IFood food)
        {
            Weight += food.Quantity * 0.35;
            FoodEaten += food.Quantity;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
