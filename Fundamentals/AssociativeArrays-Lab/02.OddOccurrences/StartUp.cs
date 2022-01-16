using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddOccurrences
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
               .Split()
               .Select(x => x.ToLower())
               .ToArray();

            Dictionary<string, int> dic = new Dictionary<string, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (dic.ContainsKey(input[i]))
                {
                    dic[input[i]]++;
                }
                else
                {
                    dic.Add(input[i], 1);
                }
            }

            foreach (var kvp in dic)
            {
                if (kvp.Value % 2 != 0)
                {
                    Console.Write($"{kvp.Key} ");
                }
            }
        }
    }
}
