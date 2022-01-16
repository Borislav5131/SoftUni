using System;
using System.Linq;

namespace _4.MatrixShuffling
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[,] matrix = new string[dimensions[0], dimensions[1]];

            matrix = FillMatrix(matrix);

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                string[] input = command.Split();

                if (input.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int rol1 = int.Parse(input[1]);
                int col1 = int.Parse(input[2]);
                int rol2 = int.Parse(input[3]);
                int col2 = int.Parse(input[4]);

                if (input[0] == "swap" &&
                    rol1 >= 0 && rol1 < matrix.GetLength(0) &&
                    col1 >= 0 && col1 < matrix.GetLength(1) &&
                    rol2 >= 0 && rol2 < matrix.GetLength(0) &&
                    col2 >= 0 && col2 < matrix.GetLength(1))
                {
                    string oldValue = matrix[rol1, col1];
                    matrix[rol1, col1] = matrix[rol2, col2];
                    matrix[rol2, col2] = oldValue;

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write($"{matrix[row, col]} ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        static string[,] FillMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine()
                .Split();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            return matrix;
        }
    }
}
