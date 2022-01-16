using System;

namespace _11.CleverLily
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double priceMachine = double.Parse(Console.ReadLine());
            double priceToys = double.Parse(Console.ReadLine());

            double presentMoney = 0;
            double totalPresentMoney = 0;
            int countOfToys = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    presentMoney += 10;
                    totalPresentMoney += presentMoney;
                    totalPresentMoney -= 1;
                }
                else
                {
                    countOfToys += 1;
                }
            }

            totalPresentMoney += countOfToys * priceToys;

            if (totalPresentMoney >= priceMachine)
            {
                double moneyLeft = totalPresentMoney - priceMachine;
                Console.WriteLine($"Yes! {moneyLeft:f2}");
            }
            else if (totalPresentMoney < priceMachine)
            {
                double neededMoney = priceMachine - totalPresentMoney;
                Console.WriteLine($"No! {neededMoney:f2}");
            }
        }
    }
}
