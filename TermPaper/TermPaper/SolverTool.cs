using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TermPaper
{
    public static class SolverTool
    {
        //      | prod1 | prod2 | prod3 | demand |
        //cons1 |_______|_______|_______|________|
        //cons2 |_______|_______|_______|________|
        //cons3 |_______|_______|_______|________|
        //stock |_______|_______|_______|



        private static Tariff[,] tariffs;
        private static List<Consumer> consumers;
        private static List<Producer> producers;
        private const int ProducerAmount = 4;
        private const int ConsumerAmount = 5;
        private const int AddToMax = 1;

        public static void NorthWestMethod(Tariff[,] tariffs)
        {
            int horIndex, verIndex;
            horIndex = verIndex = 0;
            int demand = consumers[verIndex].Demand;
            int stock = producers[horIndex].Stock;
            while (horIndex < tariffs.GetLength(1) && verIndex < tariffs.GetLength(0))
            {
                int difference = demand - stock;
                if (difference != 0)
                {
                    if(difference > 0)
                    {
                        tariffs[verIndex, horIndex].SetAmount(stock);
                        demand -= stock;
                        if (++horIndex < tariffs.GetLength(1))
                        {
                            stock = producers[horIndex].Stock;
                        }
                    }
                    else
                    {
                        tariffs[verIndex, horIndex].SetAmount(demand);
                        stock -= demand;
                        if (++verIndex < tariffs.GetLength(0))
                        {
                            demand = consumers[verIndex].Demand;
                        }
                    }
                }
                else
                {
                    tariffs[verIndex, horIndex].SetAmount(stock);
                    //самый юго восточный элемент матрицы
                    if (horIndex + 1 >= tariffs.GetLength(1) && verIndex + 1 >= tariffs.GetLength(0))
                    {
                        break;
                    }
                    if (verIndex + 1 < tariffs.GetLength(1))
                    {
                        stock -= demand;
                        demand = consumers[++verIndex].Demand;
                    }
                    else
                    {
                        demand -= stock;
                        stock = producers[++horIndex].Stock;
                    }
                    tariffs[verIndex, horIndex].SetAmount(0);
                }
            }
        }

        public static void InitializeTariffs(string[,] matrix)
        {
            InitializeItems(matrix);
            tariffs = new Tariff[consumers.Count + 1, producers.Count + 1];
            double MaxRate = 0;
            for (int i = 0; i < ConsumerAmount; i++)
            {
                for (int j = 0; j < ProducerAmount; j++)
                {
                    try
                    {
                        double rate = double.Parse(matrix[i, j]);
                        if (rate > MaxRate)
                        {
                            MaxRate = rate;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            for (int i = 0; i < ConsumerAmount; i++)
            {
                for (int j = 0; j < ProducerAmount; j++)
                {
                    if (double.TryParse(matrix[i,j], out double rate))
                    {
                        tariffs[i, j] = new Tariff(producers[j], consumers[i], rate);
                    }
                    else
                    {
                        tariffs[i, j] = new Tariff(producers[j], consumers[i], MaxRate + AddToMax);
                    }
                }
            }
            int balance = GetSum(SumType.Stock) - GetSum(SumType.Demand);
            if (balance != 0)
            {
                if (balance > 0)
                {
                    consumers.Add(new Consumer(balance));
                    ResizeTariffArray(ref tariffs, tariffs.GetLength(0), tariffs.GetLength(1) - 1);
                    for (int i = 0; i < producers.Count(); i++)
                    {
                        tariffs[tariffs.GetLength(0) -1, i] = new Tariff(producers[i], consumers[consumers.Count-1], MaxRate + AddToMax);
                    }
                }
                else
                {
                    producers.Add(new Producer(Math.Abs(balance)));
                    ResizeTariffArray(ref tariffs, tariffs.GetLength(0) - 1, tariffs.GetLength(1));
                    for (int i = 0; i < consumers.Count(); i++)
                    {
                        tariffs[i, tariffs.GetLength(1) - 1] = new Tariff(producers[producers.Count - 1], consumers[i], MaxRate + AddToMax);
                    }
                }
            }
            else
            {
                ResizeTariffArray(ref tariffs, ConsumerAmount, ProducerAmount);
            }
        }

        private static void ResizeTariffArray(ref Tariff[,] array, int rows, int cols)
        {
            Tariff[,] newArray = new Tariff[rows, cols];
            for (int i = 0; i < newArray.GetLength(0); i++)
            {
                for (int j = 0; j < newArray.GetLength(1); j++)
                {
                    if(i >= array.GetLength(0) || j >= array.GetLength(1))
                    {
                        newArray[i,j] = null;
                    }
                    else
                    {
                        newArray[i, j] = array[i, j];
                    }
                }
            }
            array = newArray;
        }

        private static void InitializeItems(string[,] matrix)
        {
            Consumer.Reset();
            Producer.Reset();
            consumers = new List<Consumer>();
            producers = new List<Producer>();
            for (int i = 0; i < ConsumerAmount; i++)
            {
                consumers.Add(new Consumer(int.Parse(matrix[i, matrix.GetLength(1) -1])));
            }
            for (int i = 0; i < ProducerAmount; i++)
            {
                producers.Add(new Producer(int.Parse(matrix[matrix.GetLength(0) - 1, i])));
            }
        }

        private enum SumType
        {
            Demand,
            Stock
        }

        private static int GetSum(SumType type)
        {
            int length = type == SumType.Demand ? consumers.Count : producers.Count;
            int sum = 0;
            for (int i = 0; i < length; i++)
            {
                if (type == SumType.Demand)
                {
                    sum += consumers[i].Demand;
                }
                else
                {
                    sum += producers[i].Stock;
                }
            }
            return sum;
        }

        public static string[,] GetAmountArray()
        {
            NorthWestMethod(tariffs);
            string[,] array = new string[ConsumerAmount + 1, ProducerAmount + 1];
            for (int i = 0; i < ConsumerAmount; i++)
            {
                for (int j =0; j < ProducerAmount; j++)
                {
                    array[i,j] = tariffs[i,j].Amount.ToString();
                }
                array[i, ProducerAmount] = consumers[i].Demand.ToString();
            }
            for (int i = 0; i < ProducerAmount; i++)
            {
                array[ConsumerAmount, i] = producers[i].Stock.ToString();
            }
            return array;
        }
    }
}
