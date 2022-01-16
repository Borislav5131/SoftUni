using System;

namespace _04.CatFood
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfCats = int.Parse(Console.ReadLine());

            int group1 = 0;
            int group2 = 0;
            int group3 = 0;
            double totalFood = 0;

            for (int i = 1; i <= numberOfCats; i++)
            {
                double foodEaten = double.Parse(Console.ReadLine());
                totalFood += foodEaten;

                if (foodEaten >= 100 && foodEaten < 200)
                {
                    group1 += 1;
                }
                else if (foodEaten >= 200 && foodEaten < 300)
                {
                    group2 += 1;
                }
                else if (foodEaten >= 300 && foodEaten < 400)
                {
                    group3 += 1;
                }
            }
            totalFood /= 1000;
            totalFood *= 12.45;

            Console.WriteLine($"Group 1: {group1} cats.");
            Console.WriteLine($"Group 2: {group2} cats.");
            Console.WriteLine($"Group 3: {group3} cats.");
            Console.WriteLine($"Price for food per day: {totalFood:f2} lv.");
        }
    }
}
