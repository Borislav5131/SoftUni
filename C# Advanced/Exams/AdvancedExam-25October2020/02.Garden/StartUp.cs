using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Garden
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[dimensions[0], dimensions[1]];

            Dictionary<int, int> flowersPositions = new Dictionary<int, int>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Bloom Bloom Plow")
                {
                    break;
                }

                int[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int currRow = tokens[0];
                int currCol = tokens[1];

                if (!ValidCordinates(matrix, currRow, currCol))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                matrix[currRow, currCol] = 1;
                flowersPositions.Add(currRow, currCol);
            }

            Bloom(matrix, flowersPositions);
            PrintGarden(matrix);
        }

        public static void PrintGarden(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }

                Console.WriteLine();
            }
        }

        public static void Bloom(int[,] matrix, Dictionary<int, int> flowersPositions)
        {
            foreach (var kvp in flowersPositions)
            {
                int currRow = kvp.Key;
                int currCol = kvp.Value;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (row != currRow)
                    {
                        matrix[row, currCol]++;
                    }
                }

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col != currCol)
                    {
                        matrix[currRow, col]++;
                    }
                }
            }
        }

        public static bool ValidCordinates(int[,] matrix, int currRow, int currCol)
        {
            if (currRow >= 0 && currRow < matrix.GetLength(0) &&
                currCol >= 0 && currCol < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}
