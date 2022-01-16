
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        public List<Racer> Racers { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return Racers.Count;
            }
        }

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Racers = new List<Racer>();
        }

        public void Add(Racer Racer)
        {
            if (Racers.Count < Capacity)
            {
                Racers.Add(Racer);
            }
        }

        public bool Remove(string name)
        {
            foreach (var racer in Racers)
            {
                if (racer.Name == name)
                {
                    return Racers.Remove(racer);
                }
            }

            return false;
        }

        public Racer GetOldestRacer()
        {
            return Racers.OrderByDescending(x => x.Age).First();
        }

        public Racer GetRacer(string name)
        {
            return Racers.Where(x => x.Name == name).FirstOrDefault();
        }

        public Racer GetFastestRacer()
        {
            return Racers.OrderByDescending(x => x.Car.Speed).First();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {Name}:");
            foreach (var racer in Racers)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
