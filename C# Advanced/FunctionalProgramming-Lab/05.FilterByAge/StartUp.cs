using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> ageByName = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(", ");

                ageByName.Add(tokens[0], int.Parse(tokens[1]));
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            ageByName = Filtering(ageByName, condition, age);

            foreach (var kvp in ageByName)
            {
                Printing(kvp.Key,kvp.Value, format);
            }

        }
        static void Printing(string kvpKey, int kvpValue, string format)
        {
            if (format == "name")
            {
                Console.WriteLine(kvpKey);
            }
            else if (format == "age")
            {
                Console.WriteLine(kvpValue);
            }
            else if (format == "name age")
            {
                Console.WriteLine($"{kvpKey} - {kvpValue}");
            }
        }


        static Dictionary<string, int> Filtering(Dictionary<string, int> ageByName, string condition,int age)
        {
            if (condition == "younger")
            {
                ageByName = ageByName
                    .Where(x => x.Value < age)
                    .ToDictionary(x => x.Key, x => x.Value);
            }
            else if (condition == "older")
            {
                ageByName = ageByName
                    .Where(x => x.Value >= age)
                    .ToDictionary(x => x.Key, x => x.Value);
            }
            return ageByName;
        }
    }
}
