using System;

namespace _03.Vacation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            string typeOfPeople = Console.ReadLine();
            string day = Console.ReadLine();

            double price = 0;
            double totalPrice = 0;

            if (typeOfPeople == "Students")
            {
                if (day == "Friday")
                {
                    price = 8.45;
                }
                else if (day == "Saturday")
                {
                    price = 9.80;
                }
                else if (day == "Sunday")
                {
                    price = 10.46;
                }

                totalPrice = price * countOfPeople;

                if (countOfPeople >= 30)
                {
                    totalPrice -= totalPrice * 0.15;
                }

            }
            else if (typeOfPeople == "Business")
            {
                if (day == "Friday")
                {
                    price = 10.90;
                }
                else if (day == "Saturday")
                {
                    price = 15.60;
                }
                else if (day == "Sunday")
                {
                    price = 16;
                }

                if (countOfPeople >= 100)
                {
                    countOfPeople -= 10;
                }

                totalPrice = price * countOfPeople;

            }
            else if (typeOfPeople == "Regular")
            {
                if (day == "Friday")
                {
                    price = 15;
                }
                else if (day == "Saturday")
                {
                    price = 20;
                }
                else if (day == "Sunday")
                {
                    price = 22.50;
                }

                totalPrice = price * countOfPeople;

                if (countOfPeople >= 10 && countOfPeople <= 20)
                {
                    totalPrice -= totalPrice * 0.05;
                }

            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
