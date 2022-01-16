using System;
using System.Text.RegularExpressions;

namespace Project2
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(\S+)>(?<g1>\d{3})\|(?<g2>[a-z]{3})\|(?<g3>[A-Z]{3})\|(?<g4>[^<>]{3})<\1");

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string password = Console.ReadLine();

                Match match = regex.Match(password);

                if (match.Success)
                {
                    string result = "";
                    result += match.Groups["g1"].Value.ToString();
                    result += match.Groups["g2"].Value.ToString();
                    result += match.Groups["g3"].Value.ToString();
                    result += match.Groups["g4"].Value.ToString();

                    Console.WriteLine($"Password: {result}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
