using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.OpinionPoll
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> persons = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                Person person = new Person(input[0],int.Parse(input[1]));
                persons.Add(person);
            }

            persons = persons
                .Where(x => x.Age > 30)
                .OrderBy(x => x.Name)
                .ToList();

            foreach (var person in persons)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
