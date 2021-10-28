using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GeneticAlgoritm
{
    public class GenericAlgoritm
    {
        private int GenerationLen; // количество особей в поколении

        private int MaxIteration; // максимальное количество итераций

        private double CrossoverProbabiity; // вероятность скрещивания

        private double MutationProbability; // вероятность мутации

        Random Rand = new Random(1344); // рандом, который скорее всего не будет работать (как всегда)

        private List<ProductChromosomeModel> Generation; // само поколение

        private double GenerationAvg;

        public GenericAlgoritm(int generationLen = 20, int maxIteration = 50, double crossover = 0.9, double mutation = 0.1)
        {
            GenerationLen = generationLen;
            MaxIteration = maxIteration;
            CrossoverProbabiity = crossover;
            MutationProbability = mutation;
        }

        public double RandomDouble(double min = 0.0, double max = 1.0)
        {
            return Rand.NextDouble() * (max - min) + min;
        }

        private void PrintStatistic(int iteration)
        {
            Generation = Generation.OrderByDescending(x => x.Value).ToList();
            Console.WriteLine($"Лучший в поколении {iteration}: {Generation[0]}");
            GenerationAvg = Generation.Average(x => x.Value);
            Console.WriteLine($"\tАвг поколения: {GenerationAvg}");

            //var normal = generation.Where(x => x.Value > 0).ToList();
            //int normalCount = normal.Count();

            //if (normal.Count() > 0)
            //    Console.Write($"Худший в поколении {i + 1}: {normal[normalCount - 1]}\n");
        }

        public void StartAlgoritm()
        {
            bool flag = true;
            // формируем первое поколение
            Generation = CreateGeneration();
            // для статистики
            PrintStatistic(0);

            for (int i = 1; i <= MaxIteration; ++i)
            {
                Generation = Generation.OrderByDescending(x => x.Value).ToList();                

                // проверяем на ответ задачи
                if (Generation[0].Value >= 1)
                {
                    Console.Write("Лучший результат: " + Generation[0]);
                    flag = false;
                    break;
                }           

                // отбор
                Generation = TournamentSelection(Generation, 2);

                //скрещивание
                for (int j = 0; j < Generation.Count - 1; j += 2)
                {
                    if (RandomDouble() < CrossoverProbabiity)
                    {
                        Generation[j].TwoPointCrossover(Generation[j + 1], Rand);
                    }                                           
                }

                // мутация
                foreach (var individual in Generation)
                {
                    if (RandomDouble() < MutationProbability)
                    {
                        individual.Mutation(Rand);
                    }                      
                }

                // для статистики
                PrintStatistic(i);
            }
            // Если не решили задачу, то выводим ближайший результат
            if (flag)
            {
                Generation = Generation.OrderByDescending(x => x.Value).ToList();
                Console.Write("Лучший результат: " + Generation[0]);
            }              
        }

        #region create

        private List<ProductChromosomeModel> CreateGeneration()
        {
            List<ProductChromosomeModel> result = new List<ProductChromosomeModel>();

            for (int i = 0; i < GenerationLen; ++i)
            {
                result.Add(CreateProductChromosomeModel());
            }

            return result;
        }

        public ProductChromosomeModel CreateProductChromosomeModel()
        {
            List<bool> list = new List<bool>();

            for (int i = 0; i < MetaData.Len; ++i)
            {
                // заполняем список случайными продуктами
                int random = Rand.Next(0, 2);
                list.Add(random == 1 ? true : false);                 
            }

            return new ProductChromosomeModel(list);
        }

        #endregion

        private List<ProductChromosomeModel> TournamentSelection(List<ProductChromosomeModel> list, int tournamentSize = 2)
        {
            List<ProductChromosomeModel> result = new List<ProductChromosomeModel>();

            // Добавляем 10% поколения без изменений
            int isNotCanChange = Convert.ToInt32(Generation.Count() * 0.1);
            for (int i = 0; i < isNotCanChange; ++i)
            {
                var product = (ProductChromosomeModel)Generation[i].Clone();
                product.SetUnchanged();
                result.Add(product);
            }

            // формируем список из n (list.Count) особей
            for (int i = isNotCanChange; i < list.Count; ++i)
            {
                List<ProductChromosomeModel> tournament = new List<ProductChromosomeModel>();
                // выбираем участников турнира
                for (int j = 0; j < tournamentSize; ++j)
                {
                    while (true)
                    {
                        var individual = list[Rand.Next(list.Count)];
                        if (!tournament.Contains(individual))
                        {
                            tournament.Add(individual);
                            break;
                        }
                    }                    
                }

                if (tournament.Where(x => x.Value <= 0.00001).Count() == tournamentSize) // можно и 0, но от греха подальше 0.00001
                {
                    i--;
                    continue;
                }

                // выбраем лучшего, мб через linq можно в 1 строчку, но пока так =)
                double maxFitness = 0;
                ProductChromosomeModel bestIndvidual = null;
                foreach (var pr in tournament)
                {
                    if (pr.Value > maxFitness)
                    {
                        maxFitness = pr.Value;
                        bestIndvidual = pr;
                    }
                }

                result.Add((ProductChromosomeModel)bestIndvidual.Clone());
            }

            return result;
        }

        private void OnePointCrossover(ProductChromosomeModel child1, ProductChromosomeModel child2)
        {
            int slice = Rand.Next(2, MetaData.Len - 2);

            List<bool> temp = new List<bool>();
            for (int i = slice; i < MetaData.Len; ++i)
            {
                temp.Add(child1.BoolProducts[i]);
            }
            for (int i = slice; i < MetaData.Len; ++i)
            {
                child1.BoolProducts[i] = child2.BoolProducts[i];
                child2.BoolProducts[i] = temp[i - slice];
            }
        }
    }
}
