namespace _04.BorderControl
{
    public class Pet : IBirthdabel
    {
        public string Name { get; }
        public string Birthdates { get; }

        public Pet(string name, string birthdates)
        {
            Name = name;
            Birthdates = birthdates;
        }
    }
}
