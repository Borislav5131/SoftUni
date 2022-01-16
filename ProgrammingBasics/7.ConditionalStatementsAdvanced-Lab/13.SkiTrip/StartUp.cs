using System;

namespace _13.SkiTrip
{
    class StartUp
    {
        static void Main(string[] args)
        {
            const double roomForOnePersonPrice = 18.00;
            const double apartmentPrice = 25.00;
            const double presidentApartmentPrice = 35.00;

            double days = double.Parse(Console.ReadLine()) - 1;
            string room = Console.ReadLine();
            string mark = Console.ReadLine();

            double totalMoney = 0;
            switch (room)
            {
                case "room for one person":
                    totalMoney = days * roomForOnePersonPrice;
                    break;
                case "apartment":
                    totalMoney = days * apartmentPrice;
                    if (days < 10)
                    {
                        totalMoney -= totalMoney * 0.30;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        totalMoney -= totalMoney * 0.35;
                    }
                    else if (days > 15)
                    {
                        totalMoney -= totalMoney * 0.50;
                    }
                    break;
                case "president apartment":
                    totalMoney = days * presidentApartmentPrice;
                    if (days < 10)
                    {
                        totalMoney -= totalMoney * 0.10;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        totalMoney -= totalMoney * 0.15;
                    }
                    else if (days > 15)
                    {
                        totalMoney -= totalMoney * 0.20;
                    }
                    break;
            }
            if (mark == "positive")
            {
                totalMoney += totalMoney * 0.25;
            }
            else if (mark == "negative")
            {
                totalMoney -= totalMoney * 0.10;
            }

            Console.WriteLine($"{totalMoney:f2}");
        }
    }
}
