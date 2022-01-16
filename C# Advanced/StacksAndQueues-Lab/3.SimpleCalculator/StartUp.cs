using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.SimpleCalculator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .Reverse()
                .ToArray();
            Stack<string> calk = new Stack<string>(input);

            while(calk.Count > 1)
            {
                int number1 = int.Parse(calk.Pop());
                string sing = calk.Pop();
                int number2 = int.Parse(calk.Pop());

                if (sing == "+")
                {
                    calk.Push((number1 + number2).ToString());
                }
                else if (sing == "-")
                {
                    calk.Push((number1 - number2).ToString());
                }
            }

            Console.WriteLine(calk.Peek());
        }
    }
}
