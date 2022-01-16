using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace _07.RawData
{
    public class Cargo
    {
        public int Weight { get; set; }
        public string Type { get; set; }


        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }
    }
}
