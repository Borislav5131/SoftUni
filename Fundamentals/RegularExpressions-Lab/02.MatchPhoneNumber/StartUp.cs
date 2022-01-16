using System;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string regex = @"[ +]359[ -]2[ -]\d{3}[ -]\d{4}";

            string number = Console.ReadLine();

            MatchCollection matches = Regex.Matches(number, regex);

            Console.Write(string.Join(", ", matches));
        }
    }
}
