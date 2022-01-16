using System;
using System.Linq;

namespace _02.ShootForTheWin
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int lastShotTarget = int.MinValue;
            int shotTargetCount = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                int index = int.Parse(input);

                if (index >= 0 && index < targets.Length)
                {
                    int savedTarget = targets[index];
                    int savedIndex = index;
                    targets[index] = -1;
                    lastShotTarget = index;
                    shotTargetCount++;

                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (i == index)
                        {
                            continue;
                        }

                        if (targets[i] == -1)
                        {
                            continue;
                        }

                        if (targets[i] > savedTarget)
                        {
                            targets[i] -= savedTarget;
                        }
                        else if (targets[i] <= savedTarget)
                        {
                            targets[i] += savedTarget;
                        }
                    }
                }

            }

            Console.WriteLine($"Shot targets: {shotTargetCount} -> {string.Join(" ", targets)}");
        }
    }
}
