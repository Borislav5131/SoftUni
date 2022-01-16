using System;

namespace _03.CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char finish = char.Parse(Console.ReadLine());

            CharactersInRange(start, finish);
        }
        static void CharactersInRange(char start, char finish)
        {
            if (start > finish)
            {
                for (int i = finish + 1; i < start; i++)
                {
                    Console.Write($"{(char)i} ");
                }
            }
            else
            {
                for (int i = start + 1; i < finish; i++)
                {
                    Console.Write($"{(char)i} ");
                }
            }
        }
    }
}
