using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _10.PredicateParty_
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();


            while (true)
            {
                string[] tokens = Console.ReadLine().Split();

                if (tokens[0] == "Party!")
                {
                    break;
                }
                else if(tokens[0] == "Remove")
                {
                    string str = tokens[2];

                    if (tokens[1] == "StartsWith")
                    {
                        for (int i = 0; i < names.Count; i++)
                        {
                            if (names[i].StartsWith(str))
                            {
                                names.Remove(names[i]);
                            }
                        }
                    }
                    else if (tokens[1] == "EndsWith")
                    {
                        for (int i = 0; i < names.Count; i++)
                        {
                            if (names[i].EndsWith(str))
                            {
                                names.Remove(names[i]);
                            }
                        }
                    }
                }
                else if (tokens[0] == "Double")
                {
                    string lenght = tokens[2];

                    for (int i = 0; i < names.Count; i++)
                    {
                        if (names[i].Length == lenght.Length)
                        {
                            names.Insert(names.IndexOf(names[i]) + 1,names[i]);
                        }
                    }
                }
            }

            if (names.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ",names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
