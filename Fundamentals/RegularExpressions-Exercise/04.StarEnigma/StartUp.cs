using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace _04.StarEnigma
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"[^@\-!:>]*@(?<name>[A-Za-z]+)[^@\-!:>]*:(?<population>\d+)[^@\-!:>]*!(?<type>\w)![^@\-!:>]*->(?<soldier>\d+)[^@\-!:>]*";
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 1; i <= n; i++)
            {
                string encrypted = Console.ReadLine();
                int count = 0;

                foreach (var letter in encrypted)
                {
                    if (letter == 's' || letter == 'S'||
                        letter == 't' || letter == 'T'||
                        letter == 'a' || letter == 'A'||
                        letter == 'r' || letter == 'R')
                    {
                        count++;
                    }
                }

                StringBuilder decrypted = new StringBuilder();

                foreach (var letter in encrypted)
                {
                    decrypted.Append(Convert.ToChar(letter - count));
                }

                string decryptedInput = decrypted.ToString();

                Match match = Regex.Match(decryptedInput, pattern);
                string name = match.Groups["name"].Value;
                string attackType = match.Groups["type"].Value;

                if (attackType == "A")
                {
                    attackedPlanets.Add(name);
                }
                else if (attackType == "D")
                {
                    destroyedPlanets.Add(name);
                }
            }

            List<string> orderAttackedPlanet = attackedPlanets.OrderBy(x=>x).ToList();
            List<string> orderDestroyedPlanet = destroyedPlanets.OrderBy(x=>x).ToList();

            Console.WriteLine($"Attacked planets: {orderAttackedPlanet.Count}");

            foreach (var planet in orderAttackedPlanet)
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {orderDestroyedPlanet.Count}");

            foreach (var planet in orderDestroyedPlanet)
            {
                Console.WriteLine($"-> {planet}");
            }

        }
    }
}
