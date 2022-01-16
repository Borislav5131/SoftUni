using System;

namespace _06.TriplesOfLatinLetters
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n ; i++)
            {
                char firstChar = (char)('a');

                for (int j = 0; j < n; j++)
                {
                    char seconfChar = (char)('a' + 1);

                    for (int k = 0; k < n; k++)
                    {
                        char thirdChar = (char)('a' + 2);
                        Console.WriteLine($"{firstChar}{seconfChar}{thirdChar}");
                    }
                }
            }
        }
    }
}
