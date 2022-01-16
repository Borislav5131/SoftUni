using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Person
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {Name}, Age: {Age}");

            return sb.ToString().TrimEnd();
        }
    }
}
