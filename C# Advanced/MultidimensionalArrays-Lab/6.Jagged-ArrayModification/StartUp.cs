using System;
using System.Linq;

namespace _6.Jagged_ArrayModification
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] jagged = new int[n][];

            for (int row = 0; row < jagged.Length; row++)
            {
                int[] elements = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                jagged[row] = new int[elements.Length];

                for (int col = 0; col < elements.Length; col++)
                {
                    jagged[row][col] = elements[col];
                }
            }

            while (true)
            {
                string[] tokens = Console.ReadLine().Split();
                string command = tokens[0];


                if (command == "END")
                {
                    break;
                }
                else if (command == "Add")
                {
                    int cordinateRow = int.Parse(tokens[1]);
                    int cordinateCol = int.Parse(tokens[2]);
                    int Value = int.Parse(tokens[3]);

                    if (cordinateRow >= n || cordinateRow < 0 ||
                        cordinateCol >= n || cordinateCol < 0)
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                    else
                    {
                        jagged[cordinateRow][cordinateCol] += Value;
                    }
                }
                else if (command == "Subtract")
                {
                    int cordinateRow = int.Parse(tokens[1]);
                    int cordinateCol = int.Parse(tokens[2]);
                    int Value = int.Parse(tokens[3]);

                    if (cordinateRow >= n || cordinateRow < 0 ||
                        cordinateCol >= n || cordinateCol < 0)
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                    else
                    {
                        jagged[cordinateRow][cordinateCol] -= Value;
                    }
                }
            }

            for (int row = 0; row < n; row++)
            {
                Console.WriteLine(string.Join(" ",jagged[row]));
            }
        }
    }
}
