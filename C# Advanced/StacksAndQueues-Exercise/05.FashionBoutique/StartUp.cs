using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine()
                .Split()
                .Reverse()
                .Select(int.Parse)
                .ToArray();
            int capacity = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(clothes);

            int sum = 0;
            int counter = 0;

            while (stack.Count > 0)
            {
                int num = stack.Peek();

                if (sum < capacity)
                {
                    sum += stack.Pop();
                }

                if (sum == capacity)
                {
                    counter++;
                    sum = 0;
                }

                if (sum > capacity)
                {
                    counter++;
                    sum = 0;
                    stack.Push(num);
                }
            }

            if (sum <= capacity)
            {
                counter++;
                sum = 0;
            }

            Console.WriteLine(counter);
        }
    }
}
