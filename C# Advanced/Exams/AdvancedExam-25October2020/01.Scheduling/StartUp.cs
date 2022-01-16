using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] inputTasks = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> tasks = new Stack<int>();

            foreach (var num in inputTasks)
            {
                tasks.Push(num);
            }

            int[] inputThreads = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Reverse().ToArray();
            Stack<int> threads = new Stack<int>();

            foreach (var num in inputThreads)
            {
                threads.Push(num);
            }

            int killedTask = int.Parse(Console.ReadLine());

            while (true)
            {
                int thread = threads.Peek();
                int task = tasks.Peek();

                if (task == killedTask)
                {
                    Console.WriteLine($"Thread with value {thread} killed task {killedTask}");
                    break;
                }

                if (thread >= task)
                {
                    threads.Pop();
                    tasks.Pop();
                }
                else
                {
                    threads.Pop();
                }
            }

            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
