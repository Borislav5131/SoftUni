using System;

namespace _01.DataTypeFinder
{
    class StartUp
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                int num = 0;
                double number = 0;
                char ch = 'V';
                bool isTrue = false;

                if (int.TryParse(input,out num))
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (double.TryParse(input, out number))
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (char.TryParse(input, out ch))
                {
                    Console.WriteLine($"{input} is character type");
                }
                else if (bool.TryParse(input, out isTrue))
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else 
                {
                    Console.WriteLine($"{input} is string type");
                }
            }
        }
    }
}
