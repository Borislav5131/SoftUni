﻿using System;
using System.Linq;

namespace _1.SumMatrixElements
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

            int sum = 0;

            foreach (var element in matrix)
            {
                sum += element;
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
