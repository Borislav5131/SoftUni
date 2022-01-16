using System;
using System.Linq;

namespace Project1
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                if (command == "Complete")
                {
                    break;
                }
                else if (command == "Make")
                {
                    if (tokens[1] == "Upper")
                    {
                        email = email.ToUpper();

                        Console.WriteLine(email);
                    }
                    else
                    {
                        email = email.ToLower();

                        Console.WriteLine(email);
                    }
                }
                else if (command == "GetDomain")
                {
                    int count = int.Parse(tokens[1]);

                    string domain = "";

                    domain = email.Substring(email.Length - count);

                    Console.WriteLine(domain);
                }
                else if (command == "GetUsername")
                {
                    if (email.Contains("@"))
                    {
                        int index = email.IndexOf("@");
                        string username = email.Substring(0 ,index);

                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                    }
                }
                else if (command == "Replace")
                {
                    string chr = tokens[1];

                    email = email.Replace(chr, "-");

                    Console.WriteLine(email);
                }
                else if (command == "Encrypt")
                {
                    string value = "";
                    foreach (var letter in email)
                    {
                        int n = letter;
                        value += (n.ToString() + " ");
                    }

                    Console.WriteLine(value);
                }
            }
        }
    }
}
