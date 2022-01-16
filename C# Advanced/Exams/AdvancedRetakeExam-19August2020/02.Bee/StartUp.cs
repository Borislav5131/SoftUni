using System;
using System.Xml;

namespace _02.Bee
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int rowBee = -1;
            int colBee = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row,col] == 'B')
                    {
                        rowBee = row;
                        colBee = col;
                    }
                }
            }

            string command = Console.ReadLine();
            bool isOutside = false;
            int pollinatedFlowers = 0;

            while (command != "End")
            {
                matrix[rowBee, colBee] = '.';

                switch (command)
                {
                    case "up":
                        rowBee--;

                        if (rowBee < 0 || rowBee >= matrix.GetLength(0) ||
                            colBee < 0 || colBee >= matrix.GetLength(1))
                        {
                            isOutside = true;
                            break;
                        }

                        if (matrix[rowBee, colBee] == 'O')
                        {
                            matrix[rowBee, colBee] = '.';
                            rowBee--;
                        }
                        break;
                    case "down":
                        rowBee++;

                        if (rowBee < 0 || rowBee >= matrix.GetLength(0) ||
                            colBee < 0 || colBee >= matrix.GetLength(1))
                        {
                            isOutside = true;
                            break;
                        }

                        if (matrix[rowBee, colBee] == 'O')
                        {
                            matrix[rowBee, colBee] = '.';
                            rowBee++;
                        }
                        break;
                    case "left":
                        colBee--;
                        if (rowBee < 0 || rowBee >= matrix.GetLength(0) ||
                            colBee < 0 || colBee >= matrix.GetLength(1))
                        {
                            isOutside = true;
                            break;
                        }

                        if (matrix[rowBee, colBee] == 'O')
                        {
                            matrix[rowBee, colBee] = '.';
                            colBee--;
                        }
                        break;
                    case "right":
                        colBee++;

                        if (rowBee < 0 || rowBee >= matrix.GetLength(0) ||
                            colBee < 0 || colBee >= matrix.GetLength(1))
                        {
                            isOutside = true;
                            break;
                        }

                        if (matrix[rowBee, colBee] == 'O')
                        {
                            matrix[rowBee, colBee] = '.';
                            colBee++;
                        }
                        break;
                }

                if (rowBee < 0 || rowBee >= matrix.GetLength(0) ||
                    colBee < 0 || colBee >= matrix.GetLength(1))
                {
                    isOutside = true;
                    break;
                }

                if (matrix[rowBee,colBee] == 'f')
                {
                    pollinatedFlowers++;
                    matrix[rowBee, colBee] = 'B';
                }

                matrix[rowBee, colBee] = 'B';
                command = Console.ReadLine();
            }

            if (isOutside)
            {
                Console.WriteLine("The bee got lost!");
            }

            if (pollinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
