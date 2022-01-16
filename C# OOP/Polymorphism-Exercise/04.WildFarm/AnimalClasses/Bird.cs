using System.Text;
using _04.WildFarm.Interfaces;

namespace _04.WildFarm.AnimalClasses
{
   public abstract class Bird : IAnimal
    {
        public abstract string Name { get; set; }
        public abstract double Weight { get; set; }
        public abstract int FoodEaten { get; set; }

        public abstract double WingSize { get; set; }

        public Bird(string name, double weight, double wingSize)
        {
            Name = name;
            Weight = weight;
            WingSize = wingSize;
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
            sb.AppendLine($"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]");
            return sb.ToString().TrimEnd();
        }
    }
}
