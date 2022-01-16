namespace _04.WildFarm.Interfaces
{
    public interface IAnimal
    {
        public  string Name { get; set; }
        public  double Weight { get; set; }
        public  int FoodEaten { get; set; }

        public string ProduceSound();
        public void EatFood(IFood food);
    }
}
