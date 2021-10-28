using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgoritm
{
    public class Product : ICloneable
    {
        public string Name { get; set; }

        public double Protein { get; set; }

        public double Fat { get; set; }

        public double Carb { get; set; }

        public double Price { get; set; }

        public object Clone()
        {
            return new Product { Name = Name, Carb = Carb, Price = Price, Fat = Fat, Protein = Protein };
        }
    }
}
