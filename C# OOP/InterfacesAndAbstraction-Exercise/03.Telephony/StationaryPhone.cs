using System;

namespace _03.Telephony
{
    public class StationaryPhone : ICalling
    {
        public void Call(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
