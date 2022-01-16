using System;

namespace _05.AccountBalance
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double sum = 0;

            while (true)
            {
                string text = Console.ReadLine();
                if (text == "NoMoreMoney")
                {
                    break;
                }
                double number = double.Parse(text);
                sum += number;
                if (number < 0)
                {
                    sum -= number;
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                Console.WriteLine($"Increase: {number:f2}");
            }

            Console.WriteLine($"Total: {sum:f2}");
        }
    }
}
