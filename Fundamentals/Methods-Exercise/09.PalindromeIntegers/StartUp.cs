using System;

namespace _09.PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                int numbers = int.Parse(command);

                int[] array = new int[command.Length];

                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = numbers % 10;
                    numbers /= 10;
                }

                int[] reverseArray = new int[command.Length];

                for (int i = 0; i < reverseArray.Length; i++)
                {
                    reverseArray[i] = array[i];
                }

                Array.Reverse(reverseArray);

                bool isEqual = false;

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == reverseArray[i])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                    }
                }

                if (isEqual)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
}
