using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Dyes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Dye : IDye
    {
        public int Power { get; private set; }

        public Dye(int power)
        {
            Power = power;
        }
        public void Use()
        {
            Power -= 10;
            if (Power < 0)
            {
                Power = 0;
            }
        }

        public bool IsFinished()
        {
            return Power == 0;
        }
    }
}
