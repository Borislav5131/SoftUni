using System;

namespace _03.Substring
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string removedWord = Console.ReadLine().ToLower();
            string input = Console.ReadLine();

            while (input.Contains(removedWord))
            {
                int index = input.IndexOf(removedWord);
                input = input.Remove(index, removedWord.Length);
            }

            Console.WriteLine(input);
        }
    }
}
