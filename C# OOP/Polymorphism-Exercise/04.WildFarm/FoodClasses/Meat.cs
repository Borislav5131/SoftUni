using _04.WildFarm.Interfaces;

namespace _04.WildFarm.FoodClasses
{
    public class Meat : IFood
    {
        public int Quantity { get; set; }

        public Meat(int quantity)
        {
            Quantity = quantity;
        }
    }
}
