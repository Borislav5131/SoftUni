using OnlineShop.Models.Products.Components;

namespace OnlineShop.Models.Products
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Component : Product, IComponent
    {
        protected Component(int id, string manufacturer, string model, decimal price, double overallPerformance,int generation)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            Generation = generation;
        }

        public int Generation { get; private set; }

        public override string ToString()
        {
            return $"Overall Performance: {OverallPerformance:f2}. Price: {Price:f2} - {this.GetType().Name}: {Manufacturer} {Model} (Id: {Id}) Generation: {Generation}";

        }
    }
}
