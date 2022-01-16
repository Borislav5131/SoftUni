using System;

namespace _02.SuperMario
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int rowMario = -1;
            int colMario = -1;

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row,col] == 'M')
                    {
                        rowMario = row;
                        colMario = col;
                    }
                }
            }

            bool isSaved = false;

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                char command = char.Parse(tokens[0]);
                matrix[int.Parse(tokens[1]), int.Parse(tokens[2])] = 'B';

                lives--;
                matrix[rowMario, colMario] = '-';

                switch (command)
                {
                    case 'W':
                        rowMario--;

                        if (rowMario < 0)
                        {
                            rowMario++;
                            matrix[rowMario, colMario] = 'M';
                            continue;
                        }

                        break;
                    case 'S':
                        rowMario++;

                        if (rowMario >= matrix.GetLength(0))
                        {
                            rowMario--;
                            matrix[rowMario, colMario] = 'M';
                            continue;
                        }

                        break;
                    case 'A':
                        colMario--;

                        if (colMario < 0)
                        {
                            colMario++;
                            matrix[rowMario, colMario] = 'M';
                            continue;
                        }

                        break;
                    case 'D':
                        colMario++;

                        if (colMario >= matrix.GetLength(1))
                        {
                            colMario--;
                            matrix[rowMario, colMario] = 'M';
                            continue;
                        }
                        break;
                }

                if (lives <= 0)
                {
                    matrix[rowMario, colMario] = 'X';
                    break;
                }

                if (matrix[rowMario,colMario] == 'B')
                {
                    lives -= 2;

                    if (lives <= 0)
                    {
                        matrix[rowMario, colMario] = 'X';
                        break;
                    }
                }

                if (matrix[rowMario,colMario] == 'P')
                {
                    isSaved = true;
                    matrix[rowMario, colMario] = '-';
                    break;
                }

                matrix[rowMario, colMario] = 'M';
            }

            
            if (isSaved)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }
            else
            {
                Console.WriteLine($"Mario died at {rowMario};{colMario}.");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }

                Console.WriteLine();
            }
        }
    }
}
