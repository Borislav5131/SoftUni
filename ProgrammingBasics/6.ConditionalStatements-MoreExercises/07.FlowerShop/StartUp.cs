using System;

namespace _07.FlowerShop
{
    class StartUp
    {
        static void Main(string[] args)
        {
            const double magnolias = 3.25;
            const double hyacinths = 4;
            const double roses =3.50 ;
            const double cactis = 8 ;

            int countOfMagnolias = int.Parse(Console.ReadLine());
            int countOfHyacinths = int.Parse(Console.ReadLine());
            int countOfRoses = int.Parse(Console.ReadLine());
            int countOfCactis = int.Parse(Console.ReadLine());
            double priceForPresent = double.Parse(Console.ReadLine());

            double totalSum = magnolias * countOfMagnolias + hyacinths * countOfHyacinths + roses * countOfRoses + cactis * countOfCactis;
            double tax = totalSum * 0.05;
            double finalSum = totalSum - tax;

            if (priceForPresent <= finalSum)
            {
                double leftMoney =Math.Floor(finalSum - priceForPresent);
                Console.WriteLine($"She is left with {leftMoney} leva.");
            }
            else if (priceForPresent > finalSum )
            {
                double borrowMoney = Math.Ceiling(priceForPresent - finalSum);
                Console.WriteLine($"She will have to borrow {borrowMoney} leva.");
            }

        }
    }
}
