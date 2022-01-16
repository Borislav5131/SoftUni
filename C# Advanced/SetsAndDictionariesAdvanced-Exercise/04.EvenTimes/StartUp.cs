using System;
using System.Collections.Generic;

namespace _04.EvenTimes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> dic = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!dic.ContainsKey(num))
                {
                    dic.Add(num, 0);
                }
                dic[num]++;
            }

            foreach (var num in dic)
            {
                if (num.Value % 2 == 0)
                {
                    Console.WriteLine(num.Key);
                }
            }
        }
    }
}
