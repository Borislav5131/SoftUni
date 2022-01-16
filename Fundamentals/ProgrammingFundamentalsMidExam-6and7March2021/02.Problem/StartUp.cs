using System;
using System.Linq;

namespace _02.Problem
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] cookies = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Eat")
                {
                    break;
                }

                string[] parts = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                string biscuit = parts[1];

                if (command == "Update-Any")
                {
                    if (cookies.Contains(biscuit))
                    {
                        int index = Array.IndexOf(cookies, biscuit);
                        cookies[index] = "Out of stock";
                    }
                }
                else if (command == "Remove")
                {
                    int index = int.Parse(parts[2]);

                    if (index > 0 && index < cookies.Length)
                    {
                        for (int i = 0; i < cookies.Length; i++)
                        {
                            if (i == index)
                            {
                                cookies[i] = biscuit;
                            }
                        }
                    }
                }
                else if (command == "Update-Last")
                {
                    cookies[cookies.Length - 1] = biscuit;
                }
                else if (command == "Rearrange")
                {
                    for (int i = 0; i < cookies.Length; i++)
                    {
                        if (cookies[i] == biscuit)
                        {
                            string removedBiscuit = cookies[i];

                            for (int k = i; k < cookies.Length - 1; k++)
                            {
                                cookies[k] = cookies[k + 1];
                            }

                            cookies[cookies.Length - 1] = removedBiscuit;
                        }
                    }
                }
            }

            cookies = cookies.Where(x => x != "Out of stock").ToArray();
            Console.WriteLine(string.Join(" ", cookies));
        }
    }
}
