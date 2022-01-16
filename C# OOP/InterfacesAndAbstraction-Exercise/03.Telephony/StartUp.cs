using System;
using System.Linq;

namespace _03.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();
            Smartphone smartPhone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (var number in numbers)
            {
                if (number.Length == 10)
                {
                    if (number.All(char.IsDigit))
                    {
                        smartPhone.Call(number);
                    }
                    else
                    {
                        Console.WriteLine("Invalid number!");
                    }
                }
                else
                {
                    if (number.All(char.IsDigit))
                    {
                        stationaryPhone.Call(number);
                    }
                    else
                    {
                        Console.WriteLine("Invalid number!");
                    }
                }
            }

            foreach (var url in urls)
            {
                if (url.Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    smartPhone.Brows(url);
                }
            }
        }
    }
}
