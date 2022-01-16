using _04.WildFarm.Interfaces;

namespace _04.WildFarm.FoodClasses
{
    public class Fruit : IFood
    {
        public int Quantity { get; set; }

        public Fruit(int quantity)
        {
            Quantity = quantity;
        }
    }
}
