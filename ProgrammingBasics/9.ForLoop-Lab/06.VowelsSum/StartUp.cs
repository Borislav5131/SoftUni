using System;

namespace _06.VowelsSum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int number = 0;

            for (int i = 0; i < text.Length; i++)
            {
                switch (text[i])
                {
                    case 'a':
                        number += 1;
                        break;
                    case 'e':
                        number += 2;
                        break;
                    case 'i':
                        number += 3;
                        break;
                    case 'o':
                        number += 4;
                        break;
                    case 'u':
                        number += 5;
                        break;
                }
            }
            Console.WriteLine(number);
        }
    }
}
