using System;

namespace _03.Vacation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double neededMoneyForExcursion = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());

            int counterDays = 0;
            int spendingCounter = 0;

            while (availableMoney < neededMoneyForExcursion && spendingCounter < 5)
            {
                counterDays++;
                string text = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());

                if (text == "spend")
                {
                    availableMoney -= money;
                    if (availableMoney <= 0)
                    {
                        availableMoney = 0;
                        continue;
                    }
                    spendingCounter++;
                }

                if (text == "save")
                {
                    availableMoney += money;
                    spendingCounter = 0;
                }

            }
            if (spendingCounter == 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine($"{counterDays}");
            }
            else if (availableMoney >= neededMoneyForExcursion)
            {
                Console.WriteLine($"You saved the money for {counterDays} days.");
            }
        }
    }
}
