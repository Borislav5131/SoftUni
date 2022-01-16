using System;
using System.Linq;

namespace _01.ReverseStrings
{
    class StartUp
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                char[] chr = input.ToCharArray();
                char[] reversedArray = chr.Reverse().ToArray();

                Console.WriteLine($"{input} = {string.Join("", reversedArray)}");
            }
        }
    }
}
