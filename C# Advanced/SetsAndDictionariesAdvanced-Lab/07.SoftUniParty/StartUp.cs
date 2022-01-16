using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.SoftUniParty
{
    class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<string> regular = new HashSet<string>(); 
            HashSet<string> vip = new HashSet<string>(); 

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                char firstLetter = command[0];
                bool isDiggit = char.IsDigit(firstLetter);
                bool isLetter = char.IsLetter(firstLetter);

                if (isDiggit)
                {
                    vip.Add(command);
                }
                else if (isLetter)
                {
                    regular.Add(command);
                }
            }
        }
    }
}
