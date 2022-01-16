using System;

namespace _04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            PasswordValidator(password);
        }

        static void PasswordValidator(string password)
        {
            bool isCorrect = false;

            char[] array = password.ToCharArray();

            if (array.Length < 6 ||
                array.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                isCorrect = false;
            }
            else
            {
                isCorrect = true;
            }

            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= 48 && array[i] <= 57 ||
                    array[i] >= 65 && array[i] <= 90 ||
                    array[i] >= 97 && array[i] <= 122)
                {
                    isCorrect = true;
                }
                else
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                    isCorrect = false;
                    break;
                }

                if (array[i] >= 48 &&
                    array[i] <= 57)
                {
                    counter++;
                }

            }

            if (counter < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                isCorrect = false;
            }

            if (isCorrect)
            {
                Console.WriteLine("Password is valid");
            }
        }
    }
}
