using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> grades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                decimal grade = decimal.Parse(tokens[1]);

                if (grades.ContainsKey(name))
                {
                    grades[name].Add(grade);
                }
                else
                {
                    grades.Add(name, new List<decimal>() {grade});
                }
            }

            foreach (var kvp in grades)
            {
                decimal averageGrade = kvp.Value.Average();
                Console.WriteLine($"{kvp.Key} -> {string.Join(" ", kvp.Value.Select(x => $"{x:f2}"))} (avg: {averageGrade:f2})");
            }
        }
    }
}
