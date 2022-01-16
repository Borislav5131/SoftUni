using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDon_tGo
{
    class StartUp
    {
        private static object list;

        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int sum = 0;
            while (sequence.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                int removedNum = 0;

                sum += sequence[index];
                removedNum = sequence[index];
                sequence.RemoveAt(index);


                if (index > sequence[sequence.Count - 1])
                {
                    sequence[sequence.Count - 1] = sequence[0];
                }

                for (int i = 0; i < sequence.Count; i++)
                {
                    if (sequence[i] <= removedNum)
                    {
                        sequence[i] += removedNum;
                    }
                    else
                    {
                        sequence[i] -= removedNum;
                    }
                }

                if (index < 0)
                {
                    sequence[0] = sequence[sequence.Count - 1];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
