using System;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    class StartUp
    {
        static void Main(string[] args)
        {

            Dictionary<string, decimal> dic = new Dictionary<string, decimal>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "stop")
                {
                    break;
                }

                string resource = input;
                decimal quantities = decimal.Parse(Console.ReadLine());

                if (dic.ContainsKey(resource))
                {
                    dic[resource] += quantities;
                }
                else
                {
                    dic.Add(resource, quantities);
                }
            }

            foreach (var kvp in dic)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
