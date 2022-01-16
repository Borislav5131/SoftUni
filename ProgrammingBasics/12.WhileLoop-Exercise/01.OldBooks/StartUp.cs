using System;

namespace _01.OldBooks
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string book = Console.ReadLine();
            string inputBook = Console.ReadLine();
            int count = 0;

            while (inputBook != "No More Books")
            {
                if (inputBook == book)
                {
                    Console.WriteLine($"You checked {count} books and found it.");
                    break;
                }
                count++;
                inputBook = Console.ReadLine();
            }

            if (inputBook != book)
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {count} books.");
            }
            
        }
    }
}
