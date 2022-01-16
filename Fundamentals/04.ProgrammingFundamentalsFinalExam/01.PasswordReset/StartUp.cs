using System;
using System.Linq;

namespace _01.PasswordReset
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            while (true)
            {
                string[] parts = Console.ReadLine().Split();

                string command = parts[0];

                if (command == "Done")
                {
                    break;
                }
                else if (command == "TakeOdd")
                {
                    string str = "";

                    for (int i = 0; i < password.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            str += password[i];
                        }
                    }

                    password = str;
                    Console.WriteLine(password);
                }
                else if (command == "Cut")
                {
                    int index = int.Parse(parts[1]);
                    int lenght = int.Parse(parts[2]);

                    string substr = password.Substring(index, lenght);
                   password = password.Replace(substr, "");

                    Console.WriteLine(password);
                }
                else if (command == "Substitute")
                {
                    string substring = parts[1];
                    string substitute = parts[2];

                    if (password.Contains(substring))
                    {
                        while (password.Contains(substring))
                        {
                            password = password.Replace(substring, substitute);
                        }

                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
