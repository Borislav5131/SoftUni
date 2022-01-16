using System;
using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string regex = @"\b(?<name>[A-Z][a-z]+ [A-Z][a-z]+)\b";

            string name = Console.ReadLine();

            MatchCollection matchedNames = Regex.Matches(name, regex);

            foreach (var kvp in matchedNames)
            {
                Console.Write(kvp + " ");
            }

            Console.WriteLine();
        }
    }
}
