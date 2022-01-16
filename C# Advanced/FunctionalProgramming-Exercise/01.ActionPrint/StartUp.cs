using System;
using System.Threading.Channels;

namespace _01.ActionPrint
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split();

            Action<string> Printer = name => Console.WriteLine(name);

            foreach (var name in input)
            {
                Printer(name);
            }
        }
    }
}
