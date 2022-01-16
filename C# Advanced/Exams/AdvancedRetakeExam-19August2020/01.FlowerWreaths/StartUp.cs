using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int wreaths = 0;
            int saved = 0;

            while (roses.Count > 0 && lilies.Count > 0)
            {
                int rose = roses.Peek();
                int lili = lilies.Peek();

                if (rose + lili == 15)
                {
                    wreaths++;
                    roses.Dequeue();
                    lilies.Pop();
                }
                else if (rose + lili > 15)
                {
                    lilies.Pop();
                    lili -= 2;
                    lilies.Push(lili);
                }
                else if (rose + lili < 15)
                {
                    saved += rose + lili;
                    roses.Dequeue();
                    lilies.Pop();
                }

            }

            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                wreaths += (saved / 15);
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}
