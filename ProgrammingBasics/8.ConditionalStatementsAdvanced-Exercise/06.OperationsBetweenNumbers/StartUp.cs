using System;

namespace _06.OperationsBetweenNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double N1 = double.Parse(Console.ReadLine());
            double N2 = double.Parse(Console.ReadLine());
            string operater = Console.ReadLine();

            double result = 0;
            string evenOrOdd = "";

            if (N2 == 0)
            {
                Console.WriteLine($"Cannot divide {N1} by zero");
            }
            else
            {
                switch (operater)
                {
                    case "+":
                        result = N1 + N2;
                        if (result % 2 == 0)
                        {
                            evenOrOdd = "even";
                        }
                        else if (result % 2 != 0)
                        {
                            evenOrOdd = "odd";
                        }
                        Console.WriteLine($"{N1} {operater} {N2} = {result} - {evenOrOdd} ");
                        break;
                    case "-":
                        result = N1 - N2;
                        if (result % 2 == 0)
                        {
                            evenOrOdd = "even";
                        }
                        else if (result % 2 != 0)
                        {
                            evenOrOdd = "odd";
                        }
                        Console.WriteLine($"{N1} {operater} {N2} = {result} - {evenOrOdd} ");
                        break;
                    case "*":
                        result = N1 * N2;
                        if (result % 2 == 0)
                        {
                            evenOrOdd = "even";
                        }
                        else if (result % 2 != 0)
                        {
                            evenOrOdd = "odd";
                        }
                        Console.WriteLine($"{N1} {operater} {N2} = {result} - {evenOrOdd} ");
                        break;
                    case "/":
                        result = N1 / N2;
                        Console.WriteLine($"{N1} / {N2} = {result:f2}");
                        break;
                    case "%":
                        result = N1 % N2;
                        Console.WriteLine($"{N1} % {N2} = {result}");
                        break;
                }
            }
        }
    }
}
