using System;

namespace _03.NewHouse
{
    class StartUp
    {
        static void Main(string[] args)
        {
            const double rosePrice = 5.00;
            const double dahliaPrice = 3.80;
            const double tulipPrice = 2.80;
            const double narcissusPrice = 3.00;
            const double gladiolusPrice = 2.50;

            string flowers = Console.ReadLine();
            int numberOfFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double totalMoney = 0;

            switch (flowers)
            {
                case "Roses":
                    totalMoney = rosePrice * numberOfFlowers;
                    if (numberOfFlowers > 80)
                    {
                        totalMoney -= totalMoney * 0.10;
                    }
                    break;
                case "Dahlias":
                    totalMoney = dahliaPrice * numberOfFlowers;
                    if (numberOfFlowers > 90)
                    {
                        totalMoney -= totalMoney * 0.15;
                    }
                    break;
                case "Tulips":
                    totalMoney = tulipPrice * numberOfFlowers;
                    if (numberOfFlowers > 80)
                    {
                        totalMoney -= totalMoney * 0.15;
                    }
                    break;
                case "Narcissus":
                    totalMoney = narcissusPrice * numberOfFlowers;
                    if (numberOfFlowers < 120)
                    {
                        totalMoney += totalMoney * 0.15;
                    }
                    break;
                case "Gladiolus":
                    totalMoney = gladiolusPrice * numberOfFlowers;
                    if (numberOfFlowers < 80)
                    {
                        totalMoney += totalMoney * 0.20;
                    }
                    break;
            }

            if (totalMoney <= budget)
            {
                double moneyLeft = budget - totalMoney;
                Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {flowers} and {moneyLeft:f2} leva left.");
            }
            else if (totalMoney > budget)
            {
                double neededMoney = totalMoney - budget;
                Console.WriteLine($"Not enough money, you need {neededMoney:f2} leva more.");
            }
        }
    }
}
