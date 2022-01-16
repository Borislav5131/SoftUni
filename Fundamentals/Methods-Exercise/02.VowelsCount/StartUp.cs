using System;

namespace _02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();

            int result = CountVowels(input);

            Console.WriteLine(result);
        }
        static int CountVowels(string input)
        {
            char[] array = new char[input.Length];
            array = input.ToCharArray();
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 'a' ||
                    array[i] == 'e' || 
                    array[i] == 'i' ||
                    array[i] == 'o' ||
                    array[i] == 'u') 
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
