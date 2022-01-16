using System;

namespace _01.TheImitationGame
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Decode")
                {
                    break;
                }

                string[] tokens = line.Split("|");

                if (tokens[0] == "Move")
                {
                    int n = int.Parse(tokens[1]);
                    string letters = input.Substring(0, n);
                    input = input.Remove(0, n);
                    input += letters;
                }
                else if(tokens[0] == "Insert")
                {
                    int index = int.Parse(tokens[1]);
                    string value = tokens[2];
                    input = input.Insert(index, value);
                }
                else if (tokens[0] == "ChangeAll")
                {
                    string substring = tokens[1];
                    string replacement = tokens[2];

                    while (input.Contains(substring))
                    {
                        input = input.Replace(substring, replacement);
                    }
                }
            }

            Console.WriteLine($"The decrypted message is: {input}");
        }
    }
}
