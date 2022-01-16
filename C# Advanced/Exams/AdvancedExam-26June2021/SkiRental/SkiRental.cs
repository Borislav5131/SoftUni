using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        public List<Ski> Skies { get; set; }
        public string Name { get; set; }
        public int  Capacity { get; set; }

        public int Count
        {
            get
            {
                return Skies.Count;
            }
        }

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Skies = new List<Ski>();
        }

        public void Add(Ski ski)
        {
            if (Skies.Count < Capacity)
            {
                Skies.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            return Skies.Remove(Skies.Where(x => x.Manufacturer == manufacturer && x.Model == model).FirstOrDefault());
        }

        public Ski GetNewestSki()
        {
            if (Skies.Count > 0)
            {
                return Skies.OrderByDescending(x => x.Year).First();
            }

            return null;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            return Skies.Where(x => x.Manufacturer == manufacturer && x.Model == model).FirstOrDefault();
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {Name}:");

            foreach (var ski in Skies)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
