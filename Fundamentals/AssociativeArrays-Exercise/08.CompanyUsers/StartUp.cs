using System;
using System.Collections.Generic;

namespace _08.CompanyUsers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> usersByCompany = new SortedDictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] tokens = input.Split(" -> ");
                string company = tokens[0];
                string id = tokens[1];

                if (!usersByCompany.ContainsKey(company))
                {
                    usersByCompany.Add(company, new List<string>());
                    usersByCompany[company].Add(id);
                }
                else
                {
                    if (!usersByCompany[company].Contains(id))
                    {
                        usersByCompany[company].Add(id);
                    }
                }
            }

            foreach (var kvp in usersByCompany)
            {
                Console.WriteLine(kvp.Key);

                foreach (var item in kvp.Value)
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
