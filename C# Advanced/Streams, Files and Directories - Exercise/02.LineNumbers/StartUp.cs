using System;
using System.IO;

namespace _02.LineNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("text.txt");

            for (int i = 0; i < input.Length; i++)
            {
                string line = input[i];
                int countLetters = 0;
                int countPunctuations = 0;

                for (int j = 0; j < line.Length; j++)
                {
                    if (char.IsLetter(line[j]))
                    {
                        countLetters++;
                    }
                    else if (char.IsPunctuation(line[j]))
                    {
                        countPunctuations++;
                    }
                }

                input[i] = $"Line {i + 1}: {line} ({countLetters})({countPunctuations})";
            }

            File.WriteAllLines("../../../output.txt", input);
        }
    }
}
