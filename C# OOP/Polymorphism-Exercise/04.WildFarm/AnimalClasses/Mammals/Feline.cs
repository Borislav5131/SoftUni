using System.Text;
using _04.WildFarm.Interfaces;

namespace _04.WildFarm.AnimalClasses.Mammals
{
    public abstract class Feline : Mammal
    {
        public abstract override string Name { get; set; }
        public abstract override double Weight { get; set; }
        public abstract override int FoodEaten { get; set; }
        public abstract override string LivingRegion { get; set; }
        public abstract string Breed { get; set; }
        public Feline(string name, double weight, string region, string breed) 
            : base(name, weight, region)
        {
            Breed = breed;
        }

        public override void EatFood(IFood food)
        {
            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]");
            return sb.ToString().TrimEnd();
        }
    }
}
