using System;

namespace _03.FootballSouvenirs
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            string souvenirs = Console.ReadLine();
            int countOfSouvenirs = int.Parse(Console.ReadLine());

            double totalSum = 0;
            bool isCorrectCountry = true;
            bool isCorrectStock = true;

            switch (team)
            {
                case "Argentina":
                    switch (souvenirs)
                    {
                        case "flags":
                            totalSum += 3.25;
                            break;
                        case "caps":
                            totalSum += 7.20;
                            break;
                        case "posters":
                            totalSum += 5.10;
                            break;
                        case "stickers":
                            totalSum += 1.25;
                            break;
                        default:
                            isCorrectStock = false;
                            break;
                    }
                    break;
                case "Brazil":
                    switch (souvenirs)
                    {
                        case "flags":
                            totalSum += 4.20;
                            break;
                        case "caps":
                            totalSum += 8.50;
                            break;
                        case "posters":
                            totalSum += 5.35;
                            break;
                        case "stickers":
                            totalSum += 1.20;
                            break;
                        default:
                            isCorrectStock = false;
                            break;
                    }
                    break;
                case "Croatia":
                    switch (souvenirs)
                    {
                        case "flags":
                            totalSum += 2.75;
                            break;
                        case "caps":
                            totalSum += 6.90;
                            break;
                        case "posters":
                            totalSum += 4.95;
                            break;
                        case "stickers":
                            totalSum += 1.10;
                            break;
                        default:
                            isCorrectStock = false;
                            break;
                    }
                    break;
                case "Denmark":
                    switch (souvenirs)
                    {
                        case "flags":
                            totalSum += 3.10;
                            break;
                        case "caps":
                            totalSum += 6.50;
                            break;
                        case "posters":
                            totalSum += 4.80;
                            break;
                        case "stickers":
                            totalSum += 0.90;
                            break;
                        default:
                            isCorrectStock = false;
                            break;
                    }
                    break;
                default:
                    isCorrectCountry = false;
                    break;
            }

            if (isCorrectCountry && isCorrectStock )
            {
                totalSum *= countOfSouvenirs;
                Console.WriteLine($"Pepi bought {countOfSouvenirs} {souvenirs} of {team} for {totalSum:f2} lv.");
            }
            else if (isCorrectCountry == false)
            {
                Console.WriteLine("Invalid country!");

            }
            else if (isCorrectStock == false)
            {
                Console.WriteLine("Invalid stock!");

            }

        }
    }
}
