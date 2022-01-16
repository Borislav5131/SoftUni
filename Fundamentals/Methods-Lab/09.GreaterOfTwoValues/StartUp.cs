using System;

namespace _09.GreaterOfTwoValues
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string first = Console.ReadLine();
            string second = Console.ReadLine();

            string result = Getmax(type, first, second);

            Console.WriteLine(result);
        }

        static string Getmax(string type, string first, string second)
        {
            string result = "";

            if (type == "int")
            {
                int firstNum = int.Parse(first);
                int secondNum = int.Parse(second);

                int maxNum = Math.Max(firstNum, secondNum);
                result = maxNum.ToString();
            }
            else if (type == "char")
            {
                char one = char.Parse(first);
                char two = char.Parse(second);

                if (one > two)
                {
                    result = first;
                }
                else
                {
                    result = second;
                }
            }
            else if (type == "string")
            {
                result = string.Compare(first, second).ToString();

                if (result == "-1")
                {
                    result = second;
                }
                else
                {
                    result = first;
                }
            }

            return result;
        }
    }
}
