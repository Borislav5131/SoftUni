using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Startup
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> studentsByCourse = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] tokens = input.Split(" : ");
                string course = tokens[0];
                string student = tokens[1];

                if (!studentsByCourse.ContainsKey(course))
                {
                    studentsByCourse.Add(course, new List<string>());
                }

                studentsByCourse[course].Add(student);

            }

            Dictionary<string, List<string>> orderedDic = studentsByCourse
                .OrderByDescending(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in orderedDic)
            {
                kvp.Value.Sort();

                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");
                foreach (var name in kvp.Value)
                {
                    Console.WriteLine($"-- {name}");
                }
            }
        }
    }
}
