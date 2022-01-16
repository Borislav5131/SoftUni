using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                .Split()
                .ToArray();

            Func<string, bool> isUpper = letter => char.IsUpper(letter[0]);

            foreach (var letter in text)
            {
                if (isUpper(letter))
                {
                    Console.WriteLine(letter);
                }
            }
        }
    }
}
