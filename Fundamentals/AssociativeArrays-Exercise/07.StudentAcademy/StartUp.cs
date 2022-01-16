using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StudentAcademy
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> gradeByStydent = new Dictionary<string, double>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string name = Console.ReadLine();
                double mark = double.Parse(Console.ReadLine());

                if (!gradeByStydent.ContainsKey(name))
                {
                    gradeByStydent.Add(name, mark);
                }
                else
                {

                }
            }

            Dictionary<string, double> orderedDic = gradeByStydent
                .Where(x => x.Value >= 4.50)
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);


            foreach (var kvp in orderedDic)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value:f2}");
            }
        }
    }
}
