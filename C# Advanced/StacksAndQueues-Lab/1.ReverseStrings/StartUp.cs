using System;
using System.Collections.Generic;

namespace _1.ReverseStrings
{
    class StartUp
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine()
                .ToCharArray();
            Stack<char> stack = new Stack<char>(input);

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
