using System;
using System.Threading.Tasks.Sources;

namespace _05.PasswordGuess
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string correctPassword = "s3cr3t!P@ssw0rd";

            if (password == correctPassword )
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}
