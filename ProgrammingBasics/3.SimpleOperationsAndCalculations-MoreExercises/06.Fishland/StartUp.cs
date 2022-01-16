using System;

namespace _06.Fishland
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double priceOfMackerel = double.Parse(Console.ReadLine());
            double priceOfSprats = double.Parse(Console.ReadLine());
            double kilogramOfBonito = double.Parse(Console.ReadLine());
            double kilogramOfHorseMackerel = double.Parse(Console.ReadLine());
            double kilogramOfMussels = double.Parse(Console.ReadLine());

            double priceOfBonito = priceOfMackerel + (priceOfMackerel * 0.6);
            double priceOfHorseMackerel = priceOfSprats + (priceOfSprats * 0.8);
            double priceOfMussels = 7.50;

            double sumForBonito = priceOfBonito * kilogramOfBonito;
            double sumOfHorseMackerel = priceOfHorseMackerel * kilogramOfHorseMackerel;
            double sumOfMussels = priceOfMussels * kilogramOfMussels;

            double finalSum = sumForBonito + sumOfHorseMackerel + sumOfMussels;

            Console.WriteLine($"{finalSum:f2}");
        }
    }
}
