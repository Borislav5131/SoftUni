using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DecryptingMessage
{
    class Startup
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            List<char> result = new List<char>();

            for (int i = 1; i <= n; i++)
            {
                char ch = char.Parse(Console.ReadLine());

                result.Add(ch + key);
            }
        }
    }
}
