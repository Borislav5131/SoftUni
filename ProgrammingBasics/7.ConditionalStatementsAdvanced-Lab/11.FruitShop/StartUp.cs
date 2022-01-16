using System;

namespace _11.FruitShop
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string day = Console.ReadLine();
            double count =double.Parse(Console.ReadLine());

            double sumOfProduct = 0;

            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Friday":
                case "Wednesday":
                case "Thursday":
                    switch (product)
                    {
                        case "banana":
                            sumOfProduct = 2.50;
                            break;
                        case "apple":
                            sumOfProduct = 1.20;
                            break;
                        case "orange":
                            sumOfProduct = 0.85;
                            break;
                        case "grapefruit":
                            sumOfProduct = 1.45;
                            break;
                        case "kiwi":
                            sumOfProduct = 2.70;
                            break;
                        case "pineapple":
                            sumOfProduct = 5.50;
                            break;
                        case "grapes":
                            sumOfProduct = 3.85;
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }
                    break;
                case "Saturday":
                case "Sunday":
                    switch (product)
                    {
                        case "banana":
                            sumOfProduct = 2.70;
                            break;
                        case "apple":
                            sumOfProduct = 1.25;
                            break;
                        case "orange":
                            sumOfProduct = 0.90;
                            break;
                        case "grapefruit":
                            sumOfProduct = 1.60;
                            break;
                        case "kiwi":
                            sumOfProduct = 3.00;
                            break;
                        case "pineapple":
                            sumOfProduct = 5.60;
                            break;
                        case "grapes":
                            sumOfProduct = 4.20;
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
            double totalSum = count * sumOfProduct;
            if (totalSum == 0)
            {
                
            }
            else
            {
                Console.WriteLine($"{totalSum:f2}");
            }
        }
    }
}
