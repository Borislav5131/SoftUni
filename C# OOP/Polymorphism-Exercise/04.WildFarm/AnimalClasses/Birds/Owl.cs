using System;
using _04.WildFarm.Interfaces;

namespace _04.WildFarm.AnimalClasses.Birds
{
   public class Owl : Bird
    {
        public override string Name { get; set; }
        public override double Weight { get; set; }
        public override int FoodEaten { get; set; }
        public override double WingSize { get; set; }


        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void EatFood(IFood food)
        {
            if (food.GetType().Name == "Meat")
            {
                Weight += food.Quantity * 0.25;
                FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
