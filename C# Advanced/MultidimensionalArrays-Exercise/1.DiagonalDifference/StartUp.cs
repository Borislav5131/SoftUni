
using System;
using System.Linq;

namespace _1.DiagonalDifference
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n,n];

            for (int row = 0; row < n; row++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int primeryDiagonal = 0;
            int secondDiagonal = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                primeryDiagonal += matrix[row, row];
                secondDiagonal += matrix[row, n - row - 1];
            }

            Console.WriteLine(Math.Abs(primeryDiagonal - secondDiagonal));
        }
    }
}
