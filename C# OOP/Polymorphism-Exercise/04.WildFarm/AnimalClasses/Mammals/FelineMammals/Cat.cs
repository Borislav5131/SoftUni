using _04.WildFarm.Interfaces;
using System;

namespace _04.WildFarm.AnimalClasses.Mammals.FelineMammals
{
    public class Cat: Feline
    {
        public override string Name { get; set; }
        public override double Weight { get; set; }
        public override int FoodEaten { get; set; }
        public override string LivingRegion { get; set; }
        public override string Breed { get; set; }
        public Cat(string name, double weight, string region, string breed)
            : base(name, weight,  region, breed)
        {
        }

        public override void EatFood(IFood food)
        {
            if (food.GetType().Name == "Vegetable")
            {
                Weight += food.Quantity * 0.30;
                FoodEaten += food.Quantity;
            }
            else if (food.GetType().Name == "Meat")
            {
                Weight += food.Quantity * 0.30;
                FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
