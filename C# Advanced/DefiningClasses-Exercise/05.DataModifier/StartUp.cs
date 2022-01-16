using System;
using System.Linq;

namespace _05.DataModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            DataModifier firstDate = new DataModifier(input1[0],input1[1],input1[1]);
            DataModifier secondDate = new DataModifier(input1[0],input1[1],input1[1]);

            Console.WriteLine(firstDate.DaysBetweenDates(firstDate,secondDate));
        }
    }
}
