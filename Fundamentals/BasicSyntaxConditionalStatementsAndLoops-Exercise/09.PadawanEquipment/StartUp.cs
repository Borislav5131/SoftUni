using System;

namespace _09.PadawanEquipment
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int countOfStudent = int.Parse(Console.ReadLine());
            double priceOfLightsabers = double.Parse(Console.ReadLine());
            double priceOfRobes = double.Parse(Console.ReadLine());
            double priceOfBelts = double.Parse(Console.ReadLine());

            int freeBelt = 0;
            int countOfStudentConstant = countOfStudent;

            for (int i = 0; i <= countOfStudent; i++)
            {
                if (i == 6)
                {
                    freeBelt++;
                    countOfStudent -= 6;
                    i = 0;
                }
            }

            double countOfSabers = Math.Ceiling(countOfStudentConstant + (countOfStudentConstant * 0.1));
            double totalSum = priceOfLightsabers * countOfSabers +
                priceOfRobes * countOfStudentConstant +
                priceOfBelts * (countOfStudentConstant - freeBelt);

            if (totalSum <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {totalSum:f2}lv.");
            }
            else
            {
                double neededMoney = totalSum - money;
                Console.WriteLine($"Ivan Cho will need {neededMoney:f2}lv more.");
            }

        }
    }
}
