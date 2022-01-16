using System;

namespace _03.DepositCalculator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double depositAmount = double.Parse(Console.ReadLine());
            int depositInMounts = int.Parse(Console.ReadLine());
            double annualInterestRate = double.Parse(Console.ReadLine());

            double interest = depositAmount * (annualInterestRate / 100);
            double interestPerMount = interest / 12;
            double finalSum = depositAmount + (depositInMounts * interestPerMount);

            Console.WriteLine(finalSum);
        }
    }
}
