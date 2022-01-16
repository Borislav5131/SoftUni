using System;

namespace _06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            MiddleChar(input);
        }

        static void MiddleChar(string input)
        {
            char[] array = input.ToCharArray();

            if (array.Length % 2 == 0)
            {
                Console.WriteLine($"{array[Convert.ToChar((array.Length / 2)- 1)]}{array[Convert.ToChar(array.Length / 2)]}");
            }
            else
            {
                Console.WriteLine($"{array[Convert.ToChar(array.Length / 2)]}");
            }
        }
    }
}
