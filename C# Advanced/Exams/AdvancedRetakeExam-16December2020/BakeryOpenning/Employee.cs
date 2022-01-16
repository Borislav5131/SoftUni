
using System.Threading.Channels;

namespace BakeryOpenning
{
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }

        public Employee(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }

        public override string ToString()
        {
            return $"Employee: {Name}, {Age} ({Country})";
        }
    }
}
