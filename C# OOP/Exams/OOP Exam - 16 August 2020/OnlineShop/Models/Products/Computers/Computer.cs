using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public override double OverallPerformance
        {
            get
            {
                if (components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                else
                {
                    var componentsAveragePerformance = Components.Any() ? Components.Average(c => c.OverallPerformance) : 0;
                    return base.OverallPerformance + componentsAveragePerformance;
                }
            }
        }


        public override decimal Price => base.Price + components.Sum(x => x.Price) + peripherals.Sum(x => x.Price);

        public IReadOnlyCollection<IComponent> Components => components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.AsReadOnly();


        public void AddComponent(IComponent component)
        {
            if (components.Any(x=>x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent comp = components.FirstOrDefault(x => x.GetType().Name == componentType);

            if ( comp is null)
            {
                throw new ArgumentException($"Component {componentType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            components.Remove(comp);
            return comp;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(x=>x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral perip = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            if ( perip is null)
            {
                throw new ArgumentException($"Peripheral {perip.GetType().Name} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            peripherals.Remove(perip);
            return perip;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Overall Performance: {this.OverallPerformance:f2}. Price: {this.Price:f2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");
            sb.AppendLine($" Components ({this.components.Count}):");

            foreach (var component in components)
            {
                sb.AppendLine($"  {component.ToString()}");
            }

            double avg = peripherals.Any() ? peripherals.Average(x => x.OverallPerformance) : 0;
            sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({avg:f2}):");

            foreach (var peripheral in peripherals)
            {
                sb.AppendLine($"  {peripheral.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
