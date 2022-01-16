using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            SortedDictionary<char, int> countSymbols = new SortedDictionary<char, int>();

            foreach (char ch in text)
            {
                if (!countSymbols.ContainsKey(ch))
                {
                    countSymbols.Add(ch, 0);
                }
                countSymbols[ch]++;
            }

            foreach (var kvp in countSymbols)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
