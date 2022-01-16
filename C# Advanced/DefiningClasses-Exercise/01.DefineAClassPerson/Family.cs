using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> persons { get; set; }

        public void AddMember(Person member)
        {
            persons.Add(member);
        }

        public Person GetOldestMember()
        {
            int maxAge = persons.Max(x => x.Age) ;
            Person oldestPerson = null;

            foreach (var person in persons)
            {
                if (person.Age == maxAge)
                {
                    oldestPerson = person;
                }
            }

            return oldestPerson;
        }
    }
}
