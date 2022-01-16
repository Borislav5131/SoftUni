using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MergingLists
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> firstNums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondNums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>();

            if (firstNums.Count >= secondNums.Count)
            {
                for (int i = 0; i < secondNums.Count; i++)
                {
                    result.Add(firstNums[i]);
                    result.Add(secondNums[i]);
                }

                firstNums.RemoveRange(0, secondNums.Count );
                result.AddRange(firstNums);

                Console.WriteLine(string.Join(" ", result));

            }
            else if (firstNums.Count < secondNums.Count)
            {
                for (int i = 0; i < firstNums.Count; i++)
                {
                    result.Add(firstNums[i]);
                    result.Add(secondNums[i]);
                }

                secondNums.RemoveRange(0, firstNums.Count);
                result.AddRange(secondNums);

                Console.WriteLine(string.Join(" ", result));
            }

        }
    }
}
