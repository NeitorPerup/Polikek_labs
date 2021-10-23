using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgoritm
{
    public class ProductChromosomeModel : ICloneable
    {
        public readonly List<Product> Products;
        public List<bool> BoolProducts;
        public double Protein { get; private set; }
        public double Carb { get; private set; }
        public double Fat { get; private set; } 
        public double Price { get; private set; }

        public double Value 
        { 
            get 
            {
                return GetValue(); 
            }
        }

        public ProductChromosomeModel(List<Product> products)
        {
            Products = products;          
            FillBoolProducts();
        }

        public void RefreshProducts()
        {
            Products.Clear();
            for(int i = 0; i < MetaData.Products.Count; ++i)
            {
                if (BoolProducts[i])
                    Products.Add(MetaData.Products[i]);
            }
        }

        private void FillBoolProducts()
        {
            BoolProducts = new List<bool>();
            foreach (var pr in MetaData.Products)
            {
                if (Products.Contains(pr))
                    BoolProducts.Add(true);
                else
                    BoolProducts.Add(false);
            }
        }

        private double GetValue()
        {
            double proteins = 0;
            double fats = 0;
            double carbs = 0;
            double price = 0;

            foreach (var product in Products)
            {
                proteins += product.Protein;
                fats += product.Fat;
                carbs += product.Carb;
                price += product.Price;
            }

            Price = price;
            Protein = proteins;
            Fat = fats;
            Carb = carbs;

            if (price > MetaData.MaxPrice || proteins >= MetaData.MaxProtein + MetaData.ProteinDeviation
                || fats >= MetaData.MaxFat + MetaData.FatDeviation || carbs >= MetaData.MaxCarb + MetaData.CarbDeviation
                || Products.Count == 0)
            {
                Mutation(new Random(), false);
                return GetValue();
            }
                

            else
                return ((proteins > MetaData.MaxProtein ? 1 : proteins / MetaData.MaxProtein) 
                    + (fats > MetaData.MaxFat ? 1 : fats / MetaData.MaxFat) 
                    + (carbs > MetaData.MaxCarb ? 1 : carbs / MetaData.MaxCarb)) / 3;                  
        }

        public void Mutation(Random rand, bool useValue = true)
        {
            if (useValue)
            {
                double value = Value;

                // если почти нашли решение, то заменяем один продукт на другой
                if (value >= 0.9)
                {
                    int gen = rand.Next(BoolProducts.Count);
                    bool genValue = BoolProducts[gen];
                    BoolProducts[gen] = !genValue;

                    // меняем один продукт на другой
                    for (int i = 0; i < BoolProducts.Count; ++i)
                    {
                        if (i == gen)
                            continue;
                        if (BoolProducts[i] != genValue)
                        {
                            BoolProducts[i] = genValue;
                            break;
                        }
                            
                    }
                }
                // иначе добавляем продукт
                else
                {
                    for (int i = 0; i < BoolProducts.Count; ++i)
                    {
                        if (!BoolProducts[i])
                        {
                            BoolProducts[i] = true;
                            break;
                        }
                            
                    }
                }
                              
            }
            else
            {
                int gen = rand.Next(BoolProducts.Count);
                BoolProducts[gen] = !BoolProducts[gen];
            }

            RefreshProducts();

        }

        public override string ToString()
        {
            string result = "";
            foreach (var pr in Products)
            {
                result += pr.Name + ", ";
            }

            result += $"\nБелков: {Protein} из {MetaData.MaxProtein}\n" +
                $"Жиров: {Fat} из {MetaData.MaxFat}\n" +
                $"Углеводов: {Carb} из {MetaData.MaxCarb}\n" +
                $"Цена: {Price} из {MetaData.MaxPrice}\n" +
                $"Value: {Value}\n";

            return result;
        }

        public object Clone()
        {
            List<Product> products = new List<Product>();
            foreach (var pr in MetaData.Products)
            {
                products.Add(pr);
            }
            return new ProductChromosomeModel(products);
        }
    }
}
