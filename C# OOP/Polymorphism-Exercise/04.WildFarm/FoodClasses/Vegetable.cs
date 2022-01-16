using _04.WildFarm.Interfaces;

namespace _04.WildFarm.FoodClasses
{
    public class Vegetable : IFood
    {
        public int Quantity { get; set; }

        public Vegetable(int quantity)
        {
            Quantity = quantity;
        }
    }
}
