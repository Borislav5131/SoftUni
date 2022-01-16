using System;

namespace _08.PetShop
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int countOfDogs = int.Parse(Console.ReadLine());
            int countOfOthersPets = int.Parse(Console.ReadLine());

            double priceOfDogsFood = 2.50;
            double priceOfOthersPetsFood = 4;

            double sumOfFoods = countOfDogs * priceOfDogsFood + countOfOthersPets * priceOfOthersPetsFood;

            Console.WriteLine($"{sumOfFoods} lv.");
        }
    }
}
