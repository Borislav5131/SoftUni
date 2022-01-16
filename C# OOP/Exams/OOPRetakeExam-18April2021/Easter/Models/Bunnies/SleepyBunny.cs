namespace Easter.Models.Bunnies
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SleepyBunny : Bunny
    {
        private const int energyConst = 50;
        public SleepyBunny(string name) : base(name, energyConst)
        {
        }

        public override void Work()
        {
            this.Energy -= 5;
            base.Work();
        }
    }
}
