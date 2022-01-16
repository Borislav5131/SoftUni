using System;
using System.ComponentModel.Design;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading.Channels;

namespace _02.SuperMario
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int livesCount = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new Char[n][];

            int rowMario = 0;
            int colMario = 0;

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                matrix[row] = new char[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row][col] = input[col];

                    if (matrix[row][col] == 'M')
                    {
                        rowMario = row;
                        colMario = col;
                    }
                }
            }

            bool isEscaped = false;

            while (true)
            {
                string[] command = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string moveCommand = command[0];
                int rowSpawn = int.Parse(command[1]);
                int colSpawn = int.Parse(command[2]);

                matrix[rowSpawn][colSpawn] = 'B';

                livesCount--;

                if (moveCommand == "W")
                {
                    if (rowMario - 1 <0)
                    {
                        continue;
                    }
                    matrix[rowMario][colMario] = '-';
                    rowMario--;
                }
                else if (moveCommand == "S")
                {
                    if (rowMario + 1 == matrix.GetLength(0))
                    {
                        continue;
                    }
                    matrix[rowMario][colMario] = '-';
                    rowMario++;
                }
                else if (moveCommand == "A")
                {
                    if (colMario - 1 <0)
                    {
                        continue;
                    }
                    matrix[rowMario][colMario] = '-';
                    colMario--;
                }
                else if (moveCommand == "D")
                {
                    if (colMario + 1 == matrix[rowMario].Length)
                    {
                        continue;
                    }
                    matrix[rowMario][colMario] = '-';
                    colMario++;
                }
                

                if (livesCount <= 0)
                {
                    matrix[rowMario][colMario] = 'X';
                    break;
                }

                if (matrix[rowMario][colMario] == 'B')
                {
                    livesCount -= 2;

                    if (livesCount <= 0)
                    {
                        matrix[rowMario][colMario] = 'X';
                        break;
                    }
                }
                else if (matrix[rowMario][colMario] == 'P')
                {
                    matrix[rowMario][colMario] = '-';
                    isEscaped = true;
                    break;
                }

                matrix[rowMario][colMario] = 'M';
            }

            if (isEscaped)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {livesCount}");
            }
            else
            {
                Console.WriteLine($"Mario died at {rowMario};{colMario}.");
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
