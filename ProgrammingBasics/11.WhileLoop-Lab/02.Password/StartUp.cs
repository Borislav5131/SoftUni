using System;

namespace _02.Password
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine(); 
            string password = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != password)
            {
                input = Console.ReadLine();
            }

            Console.WriteLine($"Welcome {name}!");
        }
    }
}
