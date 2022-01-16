using System;
using _04.WildFarm.Interfaces;

namespace _04.WildFarm.AnimalClasses.Mammals
{
    public class Mouse : Mammal
    {
        public override string Name { get; set; }
        public override double Weight { get; set; }
        public override int FoodEaten { get; set; }
        public override string LivingRegion { get; set; }
        public Mouse(string name, double weight, string region)
            : base(name, weight, region)
        {
        }

        public override void EatFood(IFood food)
        {
            if (food.GetType().Name == "Vegetable")
            {
                Weight += food.Quantity * 0.10;
                FoodEaten += food.Quantity;
            }
            else if (food.GetType().Name == "Fruit")
            {
                Weight += food.Quantity * 0.10;
                FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
