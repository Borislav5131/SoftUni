using System;
using System.Linq;

namespace _5.SquareWithMaximumSum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] parameters = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = parameters[col];
                }
            }

            int sumMax = int.MinValue;
            int indexRow = 0;
            int indexCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (sum > sumMax)
                    {
                        sumMax = sum;
                        indexRow = row;
                        indexCol = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[indexRow,indexCol]} {matrix[indexRow, indexCol+1]}");
            Console.WriteLine($"{matrix[indexRow+1,indexCol]} {matrix[indexRow+1, indexCol+1]}");
            Console.WriteLine(sumMax);
        }
    }
}
