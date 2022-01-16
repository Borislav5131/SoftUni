using System;
using System.Linq;

namespace _05.Login
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string correctPassword = string.Concat(username.Reverse());
            bool isCorrect = false;
            int counter = 0;

            while (!isCorrect)
            {
                string password = Console.ReadLine();
                counter++;

                if (correctPassword == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    isCorrect = true;
                    break;
                }
                if (counter == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }

                Console.WriteLine($"Incorrect password. Try again.");
            }
        }
    }
}
