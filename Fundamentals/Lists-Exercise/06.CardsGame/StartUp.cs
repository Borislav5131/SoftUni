using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CardsGame
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> firstHand = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondHand = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < firstHand.Count; i++)
            {
                if (firstHand[i] > secondHand[i])
                {
                    firstHand.Add(firstHand[i]);
                    firstHand.Add(secondHand[i]);
                    secondHand.RemoveAt(i);
                    i -= 1;
                }
                else if(secondHand[i] > firstHand[i])
                {
                    secondHand.Add(secondHand[i]);
                    secondHand.Add(firstHand[i]);
                    firstHand.RemoveAt(i);
                    i -= 1;
                }
                else if (firstHand[i] == secondHand[i]) 
                {
                    firstHand.RemoveAt(i);
                    secondHand.RemoveAt(i);
                }

                if (firstHand.Count <= 0)
                {
                    int sum = 0;

                    for (int k = 0; k < secondHand.Count; k++)
                    {
                        sum += secondHand[k];
                    }

                    Console.WriteLine($"Second player wins! Sum: {sum}.");

                    break;
                }
                else if (secondHand.Count <= 0)
                {
                    int sum = 0;

                    for (int k = 0; k < firstHand.Count; k++)
                    {
                        sum += firstHand[k];
                    }

                    Console.WriteLine($"First player wins! Sum: {sum}.");

                    break;
                }
            }
        }
    }
}
