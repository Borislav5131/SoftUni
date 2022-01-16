using System;
using System.Collections.Generic;

namespace _01.AdvertisementMessage
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] Phrases = new string[] { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
            string[] Events = new string[] { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            string[] Authors = new string[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] Cities = new string[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Random rnd = new Random();
                int numberPhrases = rnd.Next(Phrases.Length);
                int numberEvents = rnd.Next(Events.Length);
                int numberAuthors = rnd.Next(Authors.Length);
                int numberCities = rnd.Next(Cities.Length);

                Console.WriteLine($"{Phrases[numberPhrases]} {Events[numberEvents]} {Authors[numberAuthors]} {Cities[numberCities]}.");
            }
        }
    }
}
