namespace _06.FoodShortage
{
    public interface IBuyer
    {
        public string Name { get; }
        public int Age { get; }
        public int Food { get;}
        void BuyFood();
    }
}
