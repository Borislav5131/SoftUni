using System;
using System.Linq;

namespace _05.Digits_LettersAndOther
{
    class StartUp
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().ToCharArray();

            string digits = "";
            string letters = "";
            string characters = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    digits += text[i];
                }
                else if (char.IsLetter(text[i]))
                {
                    letters += text[i];
                }
                else
                {
                    characters += text[i];
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(characters);
        }
    }
}
