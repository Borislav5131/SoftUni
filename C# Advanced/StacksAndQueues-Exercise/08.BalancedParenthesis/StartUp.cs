using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParenthesis
{
    class StartUp
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine()
                .ToCharArray();

            Stack<char> openBrackets = new Stack<char>();
            Stack<char> closeBrackets = new Stack<char>();

            foreach (var ch in input)
            {
                if (ch == '(' ||
                    ch == '{' ||
                    ch == '[')
                {
                    openBrackets.Push(ch);
                }
                else if (ch == ')' ||
                    ch == '}' ||
                    ch == ']')
                {
                    closeBrackets.Push(ch);
                }
            }

            Stack<char> reverseStack = new Stack<char>();

            while (closeBrackets.Count>0)
            {
                reverseStack.Push(closeBrackets.Pop());
            }

            bool isEqual = false;

            while (openBrackets.Count > 0 && reverseStack.Count > 0)
            {
                char openCh = openBrackets.Pop();
                char closeCh = reverseStack.Pop();

                if (openCh == '(' && closeCh == ')')
                {
                    isEqual = true;
                    continue;
                }
                else if (openCh == '{' && closeCh == '}')
                {
                    isEqual = true;
                    continue; ;
                }
                else if (openCh == '[' && closeCh == ']')
                {
                    isEqual = true;
                    continue; ;
                }
            }

            if (isEqual)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
