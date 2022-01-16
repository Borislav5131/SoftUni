using System;
using System.Collections.Generic;

namespace _4.MatchingBrackets
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                char ch = expression[i];

                if (ch == '(')
                {
                    stack.Push(i);
                }
                else if (ch == ')')
                {
                    int openingIndex = stack.Pop();
                    string result = expression.Substring(openingIndex, i - openingIndex + 1);
                    Console.WriteLine(result);
                }
            }
        }
    }
}
