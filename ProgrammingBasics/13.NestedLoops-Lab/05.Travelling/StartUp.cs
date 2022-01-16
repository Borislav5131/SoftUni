using System;

namespace _05.Travelling
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            double savedMoney = 0;

            while (text != "End")
            {
                double budget = double.Parse(Console.ReadLine());

                while (savedMoney < budget)
                {
                    double collectMoney = double.Parse(Console.ReadLine());
                    savedMoney += collectMoney;

                    if (savedMoney >= budget )
                    {
                        Console.WriteLine($"Going to {text}!");
                    }
                }
                savedMoney = 0;
                text = Console.ReadLine();
            }
        }
    }
}
