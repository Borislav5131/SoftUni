using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Box<int>> boxes = new List<Box<int>>();
                
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>();
                box.Value = input;

                boxes.Add(box);
;           }

            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Swap(boxes, indexes[0], indexes[1]);

            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }
        }

        public static void Swap<T>(List<T> list,int index1,int index2)
        {
            T saved = list[index1];
            list[index1] = list[index2];
            list[index2] = saved;
        }
    }
}
