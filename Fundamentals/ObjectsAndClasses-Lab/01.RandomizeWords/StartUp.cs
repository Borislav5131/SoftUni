using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.RandomizeWords
{
    class StartUp
    {
        static void Main(string[] args)
        {
           string[] words = Console.ReadLine()
                 .Split();

            Random rnd = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int pos = rnd.Next(words.Length);
                string savedWord = words[i];
                words[i] = words[pos];
                words[pos] = savedWord;
            }

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
