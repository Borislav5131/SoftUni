namespace _04.BorderControl
{
    public class Citizen: IDentifible,IBirthdabel
    {
        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
        public string Birthdates { get; }

        public Citizen(string name, int age, string id,string birthdates)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdates = birthdates;
        }
    }
}
