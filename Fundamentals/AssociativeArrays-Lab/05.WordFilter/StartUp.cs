using System;

namespace _05.WordFilter
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();

            foreach (var word in array)
            {
                if (word.Length % 2 == 0)
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
