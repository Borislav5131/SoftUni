using System;
using System.Collections.Generic;

namespace _01.CountCharsInString
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            char[] chars = input.ToCharArray();

            Dictionary<char, int> dic = new Dictionary<char, int>();

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == ' ')
                {
                    continue;
                }
                if (dic.ContainsKey(chars[i]))
                {
                    dic[chars[i]]++;
                }
                else
                {
                    dic.Add(chars[i], 1);
                }
            }

            foreach (var kvp in dic)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
