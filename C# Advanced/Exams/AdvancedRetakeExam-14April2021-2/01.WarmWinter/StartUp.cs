using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.WarmWinter
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            List<int> sets = new List<int>();

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int hat = hats.Peek();
                int scarf = scarfs.Peek();
                int sum = hat + scarf;

                if (hat > scarf)
                {
                    sets.Add(sum);
                    hats.Pop();
                    scarfs.Dequeue();
                }
                else if (scarf > hat)
                {
                    hats.Pop();
                }
                else if (hat == scarf)
                {
                    scarfs.Dequeue();
                    hats.Pop();
                    hat++;
                    hats.Push(hat);
                }
            }

            int theMostExpensive = sets.Max();

            Console.WriteLine($"The most expensive set is: {theMostExpensive}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
