using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine()
                .Split(", ");

            Queue<string> queue = new Queue<string>(songs);

            while (queue.Count > 0)
            {
                string command = Console.ReadLine();
                    

                if (command.StartsWith("Play"))
                {
                    queue.Dequeue();
                }
                else if (command.StartsWith("Add"))
                {
                    command = command.Replace("Add", " ");
                    string song = command.Substring(2);

                    if (queue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(song);
                    }
                }
                else if (command.StartsWith("Show"))
                {
                    Console.WriteLine(string.Join(", ",queue));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
