using System.Text;
using _04.WildFarm.Interfaces;

namespace _04.WildFarm.AnimalClasses
{
    public abstract class Mammal : IAnimal
    {
        public abstract string Name { get; set; }
        public abstract double Weight { get; set; }
        public abstract int FoodEaten { get; set; }

        public abstract string LivingRegion { get; set; }

        public Mammal(string name, double weight, string region)
        {
            Name = name;
            Weight = weight;
            LivingRegion = region;
        }
        public virtual string ProduceSound()
        {
            return "";
        }

        public virtual void EatFood(IFood food)
        {
            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]");
            return sb.ToString().TrimEnd();
        }
    }
}
