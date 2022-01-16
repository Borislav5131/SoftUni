using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private new const double Grams = 250;
        private new const double Calories = 1000;
        private new const decimal Price = 5;

        public Cake(string name)
        :base(name, Price, Grams, Calories)
        {
            
        }
    }
}
