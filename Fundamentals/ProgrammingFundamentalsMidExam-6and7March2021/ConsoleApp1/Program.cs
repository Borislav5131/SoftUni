using System;
using System.Collections.Generic;
using System.Linq;

namespace problem2
{
    class Program
    {
        static void Main()
        {

            List<string> books = Console.ReadLine()
            .Split("&", StringSplitOptions.RemoveEmptyEntries)
            .ToList();



            string command = Console.ReadLine();

            while (command != "Done")
            {
                string[] tolkens = command
                    .Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                string nameBook = string.Empty;
                string nameBook1 = string.Empty;

                switch (tolkens[0])
                {

                    case "Add Book":

                        nameBook = tolkens[1];
                        if (!books.Contains(nameBook))
                        {
                            books.Insert(0, nameBook);
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case "Take Book":
                        nameBook = tolkens[1];
                        if (books.Contains(nameBook))
                        {
                            books.Remove(nameBook);
                        }

                        break;
                    case "Swap Books":
                        nameBook = tolkens[1];
                        nameBook1 = tolkens[2];
                        if (books.Contains(nameBook) && books.Contains(nameBook1))
                        {
                            int index1 = books.IndexOf(nameBook);
                            int index2 = books.IndexOf(nameBook1);

                            books[index1] = nameBook1;
                            books[index2] = nameBook;
                        }

                        break;

                    case "Insert Book":
                        nameBook = tolkens[1];
                        books.Add(nameBook);
                        break;
                    case "Check Book":
                        int index = int.Parse(tolkens[1]);
                        nameBook = books[index];
                        if (index >= 0 && index < books.Count)
                        {
                            Console.WriteLine(nameBook);
                        }
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", books));

        }
    }
}