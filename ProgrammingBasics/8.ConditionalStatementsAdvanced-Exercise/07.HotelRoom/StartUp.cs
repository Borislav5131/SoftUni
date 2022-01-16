using System;

namespace _07.HotelRoom
{
    class Startup
    {
        static void Main(string[] args)
        {
            const double studioMayOctober = 50.00;
            const double studioJuneSeptember = 75.20;
            const double studioJulyAugust = 76.00;
            const double apartmentMayOctober = 65.00;
            const double apartmentJuneSeptember = 68.70;
            const double apartmentJulyAugust = 77.00;

            string month = Console.ReadLine();
            int numberOfNights = int.Parse(Console.ReadLine());

            double sumStudio = 0;
            double sumApartment = 0;

            switch (month)
            {
                case "May":
                case "October":
                    sumStudio = numberOfNights * studioMayOctober;
                    if (numberOfNights > 7 && numberOfNights < 14)
                    {
                        sumStudio -= sumStudio * 0.05;
                    }
                    else if (numberOfNights > 14)
                    {
                        sumStudio -= sumStudio * 0.30;
                    }
                    sumApartment = numberOfNights * apartmentMayOctober;
                    if (numberOfNights > 14)
                    {
                        sumApartment -= sumApartment * 0.10;
                    }
                    break;
                case "June":
                case "September":
                    sumStudio = numberOfNights * studioJuneSeptember;
                    if (numberOfNights > 14)
                    {
                        sumStudio -= sumStudio * 0.20;
                    }
                    sumApartment = numberOfNights * apartmentJuneSeptember;
                    if (numberOfNights > 14)
                    {
                        sumApartment -= sumApartment * 0.10;
                    }
                    break;
                case "July":
                case "August":
                    sumStudio = numberOfNights * studioJulyAugust;
                    sumApartment = numberOfNights * apartmentJulyAugust;
                    if (numberOfNights > 14)
                    {
                        sumApartment -= sumApartment * 0.10;
                    }
                    break;
            }

            Console.WriteLine($"Apartment: {sumApartment:f2} lv.");
            Console.WriteLine($"Studio: {sumStudio:f2} lv.");
        }
    }
}
