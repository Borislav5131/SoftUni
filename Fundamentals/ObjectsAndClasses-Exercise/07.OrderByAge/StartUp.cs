using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] tokens = input.Split();

                Person person = new Person();

                person.Name = tokens[0];
                person.ID = tokens[1];
                person.Age = int.Parse(tokens[2]);

                persons.Add(person);
            }

            List<Person> orederedByAge = persons.OrderBy(x => x.Age).ToList();

            foreach (var kvp in orederedByAge)
            {
                Console.WriteLine($"{kvp.Name} with ID: {kvp.ID} is {kvp.Age} years old.");
            }
        }
    }
    class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
    }
}
