using System;

namespace _07._CinemaTickets
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            while (text != "Finish")
            {
                int sumOfStudendTicket = 0;
                int sumOfStandartTicket = 0;
                int sumOfkidTicket = 0;
                int totalTickets = 0;
                int places = 0;

                int freePlaces = int.Parse(Console.ReadLine());
                while (true)
                {
                    string ticket = Console.ReadLine();
                    if (ticket == "End")
                    {
                        break;
                    }
                    if (ticket == "student")
                    {
                        sumOfStudendTicket++;
                    }
                    else if (ticket == "standard")
                    {
                        sumOfStandartTicket++;
                    }
                    else if (ticket == "kid")
                    {
                        sumOfkidTicket++;
                    }
                    if (places >= freePlaces)
                    {
                        break;
                    }
                    places = freePlaces;
                    totalTickets++;
                }
                Console.WriteLine($"{text} - {totalTickets / places * 100}% full.");
                Console.WriteLine($"Total tickets: {totalTickets}");
                Console.WriteLine($"{sumOfStudendTicket / totalTickets * 100} student tickets.");
                Console.WriteLine($"{sumOfStandartTicket / totalTickets * 100} standard tickets.");
                Console.WriteLine($"{sumOfkidTicket / totalTickets * 100} kid tickets.");
                text = Console.ReadLine();
            }
        }
    }
}
