using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private new const double Milliliters = 50;
        private new const decimal Price = 3.50M;

        public double Caffeine { get; set; }

        public Coffee(string name, double caffeine)
        :base(name, Price, Milliliters)
        {
            Caffeine = caffeine;
        }
    }
}
