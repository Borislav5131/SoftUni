using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Queue<int> effects = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> casings = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int daturaCount = 0;
            int cherryCount = 0;
            int smokeDecoyCount = 0;
            bool isFull = false;

            while (effects.Count > 0 && casings.Count > 0)
            {
                int effect = effects.Peek();
                int casing = casings.Peek();
                int sum = effect + casing;

                if (daturaCount >= 3 && cherryCount >= 3 && smokeDecoyCount >= 3)
                {
                    isFull = true;
                    break;
                }

                switch (sum)
                {
                    case 40:
                        daturaCount++;
                        effects.Dequeue();
                        casings.Pop();
                        break;
                    case 60:
                        cherryCount++;
                        effects.Dequeue();
                        casings.Pop();
                        break;
                    case 120:
                        smokeDecoyCount++;
                        effects.Dequeue();
                        casings.Pop();
                        break;
                    default:
                        casings.Pop();
                        casing -= 5;
                        casings.Push(casing);
                        break;
                }
            }

            if (isFull)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (effects.Count <= 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", effects)}");
            }

            if (casings.Count <= 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casings)}");
            }

            Console.WriteLine($"Cherry Bombs: {cherryCount}");
            Console.WriteLine($"Datura Bombs: {daturaCount}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyCount}");
        }
    }
}
