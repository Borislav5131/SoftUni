using System;
using System.Runtime.CompilerServices;

namespace _06.Pets
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int food = int.Parse(Console.ReadLine());
            double dogFoodDay = double.Parse(Console.ReadLine());
            double catFoodDay = double.Parse(Console.ReadLine());
            double turtleFoodDay = double.Parse(Console.ReadLine()) / 1000;

            double needDogFood = days * dogFoodDay;
            double needCatFood = days * catFoodDay;
            double needTurtleFood = days * turtleFoodDay;
            double totalFood = needCatFood + needDogFood + needTurtleFood;

            if (totalFood <= food)
            {
                double leftFood =Math.Floor(food - totalFood);
                Console.WriteLine($"{leftFood} kilos of food left.");
            }
            else if (totalFood > food)
            {
                double neededFood =Math.Ceiling(totalFood - food);
                Console.WriteLine($"{neededFood} more kilos of food are needed.");
            }
        
        }
    }
}
