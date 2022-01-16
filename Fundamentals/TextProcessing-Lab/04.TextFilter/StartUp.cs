using System;

namespace _04.TextFilter
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine()
                .Split(", ");
            string text = Console.ReadLine();

            foreach (var item in bannedWords)
            {
                text = text.Replace(item, new string('*', item.Length));
            }

            Console.WriteLine(text);
        }
    }
}
