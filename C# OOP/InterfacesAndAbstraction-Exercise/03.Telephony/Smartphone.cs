using System;

namespace _03.Telephony
{
    public class Smartphone : ICalling, IBrowsing
    {
        public void Call(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }

        public void Brows(string url)
        {
            Console.WriteLine($"Browsing: {url}!");
        }
    }
}
