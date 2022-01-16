using System;

namespace _03.Calculations
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            if (input == "add")
            {
                AddNumbers(firstNum, secondNum);
            }
            else if(input == "multiply")
            {
                MultiplyNumbers(firstNum, secondNum);
            }
            else if (input == "subtract")
            {
                SubtractNumbers(firstNum, secondNum);
            }
            else if (input == "divide")
            {
                DivideNumbers(firstNum, secondNum);
            }

        }
        static void AddNumbers(int firstNum, int secondNum)
        {
            int result = firstNum + secondNum;
            Console.WriteLine(result);
        }
        static void MultiplyNumbers(int firstNum, int secondNum)
        {
            int result = firstNum * secondNum;
            Console.WriteLine(result);
        }
        static void SubtractNumbers(int firstNum, int secondNum)
        {
            int result = firstNum - secondNum;
            Console.WriteLine(result);
        }
        static void DivideNumbers(int firstNum, int secondNum)
        {
            int result = firstNum / secondNum;
            Console.WriteLine(result);
        }
    }
}
