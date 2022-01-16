using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        private new const string Gender = "Female";
        public Kitten(string name, int age)
            : base(name, age, Gender)
        {

        }

        public override string ProduceSound()
        {
            return $"Meow";
        }
    }
}
