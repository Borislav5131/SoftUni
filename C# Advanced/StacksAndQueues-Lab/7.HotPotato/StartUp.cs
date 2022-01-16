using System;
using System.Collections.Generic;

namespace _7.HotPotato
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split();
            int counter = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(names);

            while (queue.Count > 1)
            {
                for (int i = 1; i < counter; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
