namespace _06.FoodShortage  
{
    public class Citizen: IDentifible,IBirthdabel,IBuyer
    {
        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
        public string Birthdates { get; }

        public int Food { get; set; } = 0;

        public Citizen(string name, int age, string id,string birthdates)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdates = birthdates;
        }

        public void BuyFood()
        {
            Food = 10;
        }
    }
}
