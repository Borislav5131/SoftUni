using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace _01.WarmWinter
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>();
            Queue<int> scarfs = new Queue<int>();
            List<int> sets = new List<int>();

            int[] inputHats = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] inputScarfs = Console.ReadLine().Split().Select(int.Parse).ToArray();

            foreach (var hat in inputHats)
            {
                hats.Push(hat);
            }

            foreach (var scarf in inputScarfs)
            {
                scarfs.Enqueue(scarf);
            }

            while (true)
            {
                if (hats.Count <= 0 || scarfs.Count <= 0)
                {
                    break;
                }

                int hat = hats.Peek();
                int scarf = scarfs.Peek();

                if (hat > scarf)
                {
                    sets.Add(hat + scarf);
                    hats.Pop();
                    scarfs.Dequeue();
                }
                else if (hat < scarf)
                {
                    hats.Pop();
                }
                else if (hat == scarf)
                {
                    scarfs.Dequeue();
                    hat++;
                    hats.Pop();
                    hats.Push(hat);
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ",sets));

        }
    }
}
