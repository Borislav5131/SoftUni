using System;
using System.Xml;

namespace _04.Sequence2k_1
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 1;

            while (sum <= n)
            {
                Console.WriteLine(sum);
                sum = sum * 2 + 1;
            }
        }    
    }
}
