using System;

namespace _02.CalorieCalculator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string sex = Console.ReadLine();
            double weightKg = double.Parse(Console.ReadLine());
            double heightMeters = double.Parse(Console.ReadLine()) * 100;
            int age = int.Parse(Console.ReadLine());
            string levelOfPhysicalActivity = Console.ReadLine();

            double calories = 0;

            if (sex == "m")
            {
                calories = 66 + (13.7 * weightKg) + (5 * heightMeters) - (6.8 * age);
            }
            else if (sex == "f")
            {
                calories = 655 + (9.6 * weightKg) + (1.8 * heightMeters) - (4.7 * age);
            }

            if (levelOfPhysicalActivity == "sedentary")
            {
                calories *= 1.2;
            }
            else if (levelOfPhysicalActivity == "lightly active")
            {
                calories *= 1.375;
            }
            else if (levelOfPhysicalActivity == "moderately active")
            {
                calories *= 1.55;
            }
            else if (levelOfPhysicalActivity == "very active")
            {
                calories *= 1.725;
            }

            Console.WriteLine($"To maintain your current weight you will need {Math.Ceiling(calories)} calories per day.");
        }
    }
}
