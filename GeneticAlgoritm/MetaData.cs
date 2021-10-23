using System.Collections.Generic;

namespace GeneticAlgoritm
{
    public class MetaData
    {
        public const float MaxProtein = 38; // 34

        public const float MaxCarb = 75; // 60

        public const float MaxFat = 30; // 25

        public const int ProteinDeviation = 5; // 10

        public const int CarbDeviation = 10;

        public const int FatDeviation = 5;

        public const double MaxPrice = 200;

        public static int Len { get { return Products.Count; } }

        public static List<Product> Products = new List<Product>()
            {
                new Product { Name = "Яблоко", Protein = 0.4, Fat = 0.4, Carb = 9.8, Price = 20 },
                new Product { Name = "Варёное яйцо", Protein = 6.3, Fat = 5.31, Carb = 0.56, Price = 18},
                new Product { Name = "Овсянка 50г", Protein = 6.5, Fat = 3.1, Carb = 33, Price = 45},
                new Product { Name = "Сок апельсиновый 150 мл", Protein = 0, Fat = 0, Carb = 12, Price = 25},
                new Product { Name = "Йогурт белый", Protein = 4, Fat = 2.7, Carb = 6.8, Price = 30},
                new Product { Name = "Бекон 100г", Protein = 25, Fat = 20, Carb = 0, Price = 80},
                new Product { Name = "Хлеб ржаной 100г", Protein = 8.5, Fat = 3.3, Carb = 48.3, Price = 25},
                new Product { Name = "Empty", Protein = 0, Fat = 0, Carb = 0, Price = 100},
                new Product { Name = "RandomProduct", Protein = 5, Fat = 1.9, Carb = 15, Price = 100},
                new Product { Name = "Банан", Protein = 5, Fat = 1, Carb = 10, Price = 20}
            };
    }
}
