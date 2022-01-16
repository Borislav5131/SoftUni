using _04.WildFarm.Interfaces;

namespace _04.WildFarm.FoodClasses
{
    public class Seeds : IFood
    {
        public int Quantity { get; set; }

        public Seeds(int quantity)
        {
            Quantity = quantity;
        }
    }
}
