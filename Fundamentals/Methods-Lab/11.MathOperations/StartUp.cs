using System;

namespace _11.MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            string operators = Console.ReadLine();
            int secondNum = int.Parse(Console.ReadLine());

            MathOperations(firstNum, operators, secondNum);

            Console.WriteLine(MathOperations(firstNum, operators, secondNum));
        }
        static int MathOperations(int first, string operators, int second)
        {
            int result = 0;

            if (operators == "/")
            {
                result = first / second;
            }
            else if (operators == "*")
            {
                result = first * second;
            }
            else if (operators == "+")
            {
                result = first + second;
            }
            else if (operators == "-")
            {
                result = first - second;
            }

            return result;
        }
    }
}
