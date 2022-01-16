using System;
using System.Linq;

namespace _01.SecretChat
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            while (true)
            {
                string[] parts = Console.ReadLine().Split(":|:");
                string command = parts[0];

                if (command == "Reveal")
                {
                    break;
                }
                else if (command == "InsertSpace")
                {
                    message = message.Insert(int.Parse(parts[1]), " ");

                    Console.WriteLine(message);
                }
                else if (command == "Reverse")
                {
                    string substring = parts[1];

                    if (message.Contains(substring))
                    {
                        message = message.Remove(message.IndexOf(substring), substring.Length);
                        char[] array = substring.ToCharArray();
                        array = array.Reverse().ToArray();
                        substring = new string(array);
                        message += substring;

                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }

                }
                else if (command == "ChangeAll")
                {
                    message = message.Replace(parts[1], parts[2]);

                    Console.WriteLine(message);
                }
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
