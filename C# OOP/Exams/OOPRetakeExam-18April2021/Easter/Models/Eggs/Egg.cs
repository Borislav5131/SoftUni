using Easter.Models.Eggs.Contracts;
using Easter.Utilities.Messages;

namespace Easter.Models.Eggs
{
    using System;
    using System.Collections.Generic;
    using System.Text;

   public  class Egg : IEgg
   {
       private string name;
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEggName);
                }

                name = value;
            }
        }
        public int EnergyRequired { get;private set; }

        public Egg(string name , int energy)
        {
            Name = name;
            EnergyRequired = energy;
        }
        public void GetColored()
        {
            EnergyRequired -= 10;
            if (EnergyRequired < 0)
            {
                EnergyRequired = 0;
            }
        }

        public bool IsDone()
        {
            return EnergyRequired == 0;
        }
    }
}
