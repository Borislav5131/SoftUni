using System;
using System.Linq;

namespace _6.JaggedArrayManipulator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] jagged = new int[n][];

            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jagged[row] = new int[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    jagged[row][col] = input[col];
                }
            }

            AnalyzingMatrix(jagged);

            string[] command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                int rowIndex = int.Parse(command[1]);
                int colomnIndex = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (command[0] == "Add")
                {
                    if (rowIndex > 0 && rowIndex <= jagged.GetLength(0) &&
                        colomnIndex > 0 && colomnIndex <= jagged[rowIndex].Length)
                    {
                        jagged[rowIndex][colomnIndex] += value;
                    }
                }
                else if (command[0] == "Subtract")
                {
                    if (rowIndex > 0 && rowIndex <= jagged.GetLength(0) &&
                        colomnIndex > 0 && colomnIndex <= jagged[rowIndex].Length)
                    {
                        jagged[rowIndex][colomnIndex] -= value;
                    }
                }

                command = Console.ReadLine().Split();
            }

            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(" ",jagged[row]));
            }

        }

        static void AnalyzingMatrix(int[][] jagged)
        {
            for (int row = 0; row < jagged.GetLength(0) - 1; row++)
            {
                if (jagged[row].Length == jagged[row + 1].Length)
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] *= 2;
                        jagged[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] /= 2;
                    }
                    for (int col = 0; col < jagged[row + 1].Length; col++)
                    {
                        jagged[row + 1][col] /= 2;
                    }
                }
            }
        }
    }
}
