using System;

namespace _12.TradeCommissions
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());

            double comision = 0;

            switch (town)
            {
                case "Sofia":
                    if (sales >= 0 && sales <= 500)
                    {
                        comision += sales * 0.05;
                    }
                    else if (sales > 500 && sales <= 1000)
                    {
                        comision += sales * 0.07;
                    }
                    else if (sales > 1000 && sales <= 10000)
                    {
                        comision += sales * 0.08;
                    }
                    else if (sales > 10000)
                    {
                        comision += sales * 0.12;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                case "Varna":
                    if (sales >= 0 && sales <= 500)
                    {
                        comision += sales * 0.045;
                    }
                    else if (sales > 500 && sales <= 1000)
                    {
                        comision += sales * 0.075;
                    }
                    else if (sales > 1000 && sales <= 10000)
                    {
                        comision += sales * 0.10;
                    }
                    else if (sales > 10000)
                    {
                        comision += sales * 0.13;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                case "Plovdiv":
                    if (sales >= 0 && sales <= 500)
                    {
                        comision += sales * 0.055;
                    }
                    else if (sales > 500 && sales <= 1000)
                    {
                        comision += sales * 0.08;
                    }
                    else if (sales > 1000 && sales <= 10000)
                    {
                        comision += sales * 0.12;
                    }
                    else if (sales > 10000)
                    {
                        comision += sales * 0.145;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
            if (comision != 0)
            {
                Console.WriteLine($"{comision:f2}");
            }
        }
    }
}
