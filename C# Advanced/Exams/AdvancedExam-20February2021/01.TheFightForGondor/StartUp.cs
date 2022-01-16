using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.TheFightForGondor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int countOfWaves = int.Parse(Console.ReadLine());

            Stack<int> plates = new Stack<int>();
            Stack<int> wave = new Stack<int>();

            int[] inputPlates = Console.ReadLine().Split().Select(int.Parse).Reverse().ToArray();

            for (int i = 0; i < inputPlates.Length; i++)
            {
                plates.Push(inputPlates[i]);
            }

            bool isOrcWin = false;
            bool isGondorWin = false;

            for (int i = 1; i <= countOfWaves; i++)
            {
                int[] inputWave = Console.ReadLine().Split().Select(int.Parse).ToArray();

                foreach (var num in inputWave)
                {
                    wave.Push(num);
                }

                if (i % 3 == 0)
                {
                    int[] arr = plates.ToArray().Reverse().ToArray();
                    plates.Clear();
                    plates.Push(int.Parse(Console.ReadLine()));
                    foreach (var num in arr)
                    {
                        plates.Push(num);
                    }
                }
                
                for (int j = 0; j < inputWave.Length; j++)
                {
                    int orcWarrior = wave.Peek();
                    int plate = plates.Peek();

                    if (orcWarrior > plate)
                    {
                        while (orcWarrior > 0)
                        {
                            if (plates.Count == 0)
                            {
                                isOrcWin = true;
                                break;
                            }

                            plate = plates.Peek();

                            if (orcWarrior > plate)
                            {
                                plates.Pop();
                                wave.Pop();
                                wave.Push(orcWarrior -= plate);
                            }
                            else
                            {
                                plates.Pop();
                                plates.Push(plate -= orcWarrior);
                                wave.Pop();
                                break;
                            }
                        }
                    }
                    else if (orcWarrior < plate)
                    {
                        wave.Pop();
                        plates.Pop();
                        plates.Push(plate -= orcWarrior);
                    }
                    else
                    {
                        wave.Pop();
                        plates.Pop();
                    }

                    if (plates.Count == 0)
                    {
                        isOrcWin = true;
                        break;
                    }
                }

                if (plates.Count == 0)
                {
                    isOrcWin = true;
                    break;
                }
            }

            if (isOrcWin)
            {
                Console.WriteLine($"The orcs successfully destroyed the Gondor's defense.");
            }
            else
            {
                Console.WriteLine($"The people successfully repulsed the orc's attack.");
            }

            if (plates.Any())
            {
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }

            if(wave.Any())
            {
                Console.WriteLine($"Orcs left: {string.Join(", ", wave)}");
            }
        }
    }
}
