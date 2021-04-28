using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TermPaper
{
    public static class SolverTool
    {
        //      | prod1 | prod2 | prod3 | demand | U pot |
        //cons1 |_______|_______|_______|________|_______|
        //cons2 |_______|_______|_______|________|_______|
        //cons3 |_______|_______|_______|________|_______|
        //stock |_______|_______|_______|________|
        //V pot |_______|_______|_______|


        private static Tariff[,] tariffs;
        private static List<Consumer> consumers;
        private static List<Producer> producers;
        private const int ProducerAmount = 4;
        private const int ConsumerAmount = 5;
        private const int AddToMax = 1;
        private static double[] Upots;
        private static double[] Vpots; 
        public static Action Displayer;

        public static void NorthWestMethod()
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
                    if (difference > 0)
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
                    if (double.TryParse(matrix[i, j], out double rate))
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
                        tariffs[tariffs.GetLength(0) - 1, i] = new Tariff(producers[i], consumers[consumers.Count - 1], MaxRate + AddToMax);
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
                    if (i >= array.GetLength(0) || j >= array.GetLength(1))
                    {
                        newArray[i, j] = null;
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
            for (int i = 0; i < ProducerAmount; i++)
            {
                producers.Add(new Producer(int.Parse(matrix[matrix.GetLength(0) - 1, i])));
            }
            for (int i = 0; i < ConsumerAmount; i++)
            {
                consumers.Add(new Consumer(int.Parse(matrix[i, matrix.GetLength(1) - 1])));
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
            string[,] array = new string[ConsumerAmount + 1, ProducerAmount + 1];
            for (int i = 0; i < ConsumerAmount; i++)
            {
                for (int j = 0; j < ProducerAmount; j++)
                {
                    array[i, j] = tariffs[i, j].Amount.ToString();
                }
                array[i, ProducerAmount] = consumers[i].Demand.ToString();
            }
            for (int i = 0; i < ProducerAmount; i++)
            {
                array[ConsumerAmount, i] = producers[i].Stock.ToString();
            }
            return array;
        }

        public static string[,] GetPotentialArray()
        {
            string[,] array = new string[ConsumerAmount + 1, ProducerAmount + 1];
            for (int i = 0; i < ConsumerAmount; i++)
            {
                for (int j = 0; j < ProducerAmount; j++)
                {
                    array[i, j] = tariffs[i, j].Potential.ToString();
                }
                array[i, ProducerAmount] = Upots[i].ToString();
            }
            for (int i = 0; i < ProducerAmount; i++)
            {
                array[ConsumerAmount, i] = Vpots[i].ToString();
            }
            return array;
        }

        public static void SolveProblem(string[,] matrix)
        {
            InitializeTariffs(matrix);
            NorthWestMethod();
            FindOptimalSolutuion();
        }

        public static void FindOptimalSolutuion()
        {
            SetPotentials();
            double maxPotential = FindMaxPotential();
            if (maxPotential < 0)
            {
                MessageBox.Show("Оптимальное решение уже найденно! "  + maxPotential.ToString());
                return;
            }
            do
            {
                Tariff newTariff = FindTariffByPotential(maxPotential);
                newTariff.SetEmptyAmount();
                List<Tariff> filledTariffs = GetFilledTariffs();
                List<Tariff> circuitNodes = GetTariffContour(newTariff, filledTariffs);
                circuitNodes.Reverse();
                int amount = int.MaxValue;
                for (int i = 1; i < circuitNodes.Count; i += 2)
                {
                    if (circuitNodes[i].Amount < amount)
                    {
                        amount = circuitNodes[i].Amount;
                    }
                }
                for (int i = 0; i < circuitNodes.Count; i++)
                {
                    circuitNodes[i].SetAmount(circuitNodes[i++].Amount + amount);
                    if (circuitNodes[i].Amount - amount == 0)
                    {
                        circuitNodes[i].SetDefaultAmount();
                    }
                    else
                    {
                        circuitNodes[i].SetAmount(circuitNodes[i].Amount - amount);
                    }
                }
                SetPotentials();
                maxPotential = FindMaxPotential();
                Displayer?.Invoke();
            }
            while (maxPotential > 0);
        }

        enum Dimension
        {
            Rows,
            Cols
        }

        private static List<Tariff> GetTariffContour(Tariff startTariff, List<Tariff> filledTariffs)
        {
            Dimension dimension = Dimension.Cols;
            List<Tariff> tariffCircuit = new List<Tariff>();
            while (true)
            {
                Tariff nextTariff = FindTariffInDimension(startTariff, dimension, filledTariffs);
                dimension = dimension == Dimension.Rows ? Dimension.Cols : Dimension.Rows;
                Tariff tmpTariff = nextTariff;
                tariffCircuit.Clear();
                tariffCircuit.Add(nextTariff);
                while (true)
                {
                    nextTariff = FindTariffInDimension(tmpTariff, dimension, filledTariffs);
                    dimension = dimension == Dimension.Rows ? Dimension.Cols : Dimension.Rows;
                    if (nextTariff == null)
                    {
                        filledTariffs.Remove(tmpTariff);
                        break;
                    }
                    tariffCircuit.Add(nextTariff);
                    if (nextTariff == startTariff)
                    {
                        return tariffCircuit;
                    }
                    tmpTariff = nextTariff;
                }
            }
        }

        private static void ShowTariffsList(List<Tariff> fTariffs)
        {
            string mes = "";
            foreach(Tariff tariff in fTariffs)
            {
                mes += tariff.GetConsumerNum() + " " + tariff.GetProducerNum() + " " + tariff.Amount + "\n";
            }
            MessageBox.Show(mes);
        }

        private static Tariff FindTariffInDimension(Tariff startTariff, Dimension dimension, List<Tariff> tariffs)
        {
            Tariff newTariff = null;
            foreach (Tariff tariff in tariffs)
            {
                if (dimension == Dimension.Cols)
                {
                    if (tariff.GetProducerNum() == startTariff.GetProducerNum() && tariff.GetConsumerNum() != startTariff.GetConsumerNum())
                    {
                        newTariff = tariff;
                        break;
                    }
                }
                else
                {
                    if (tariff.GetConsumerNum() == startTariff.GetConsumerNum() && tariff.GetProducerNum() != startTariff.GetProducerNum())
                    {
                        newTariff = tariff;
                        break;
                    }
                }
            }
            return newTariff;
        }

        private static Tariff FindTariffByPotential(double potential)
        {
            Tariff newTariff = null;
            foreach (Tariff tariff in tariffs)
            {
                if (tariff.Amount == Tariff.Default && tariff.Potential == potential)
                {
                    newTariff = tariff;
                }
            }
            return newTariff;
        }

        private static double FindMaxPotential()
        {
            double max = -1;
            foreach (Tariff tariff in tariffs)
            {
                if (tariff.Amount == Tariff.Default && tariff.Potential > max)
                {
                    max = tariff.Potential;
                }
            }
            return max;
        }

        private static List<Tariff> GetFilledTariffs()
        {
            List<Tariff> filledTariffs = new List<Tariff>();
            foreach (Tariff tariff in tariffs)
            {
                if (tariff.Amount != Tariff.Default)
                {
                    filledTariffs.Add(tariff);
                }
            }
            return filledTariffs;
        }

        public static void SetPotentials()
        {
            List<Tariff> filledTariffs = GetFilledTariffs();
            foreach (Tariff tariff in tariffs)
            {
                tariff.ClearPotential();
                if (tariff.Amount != Tariff.Default)
                {
                    tariff.SetPotential(tariff.Rate);
                }
            }
            int Ulength = tariffs.GetLength(0) == ConsumerAmount ? ConsumerAmount : ConsumerAmount + 1;
            Upots = GetNaNArray(Ulength);
            int Vlength = tariffs.GetLength(1) == ProducerAmount ? ProducerAmount : ProducerAmount + 1;
            Vpots = GetNaNArray(Vlength);
            int startIndex = 2;
            double Vpot = Math.Floor(filledTariffs[startIndex].Rate / 2);
            Vpots[filledTariffs[startIndex].GetProducerNum() - 1] = Vpot;
            Upots[filledTariffs[startIndex].GetConsumerNum() - 1] = filledTariffs[startIndex].Rate - Vpot;
            while (filledTariffs.Count > 0)
            {
                foreach (Tariff tariff in filledTariffs)
                {
                    if (!(double.IsNaN(Vpots[tariff.GetProducerNum() - 1])) && !(double.IsNaN(Upots[tariff.GetConsumerNum() - 1])))
                    {
                        filledTariffs.Remove(tariff);
                        break;
                    }
                    if (double.IsNaN(Vpots[tariff.GetProducerNum() - 1]) && double.IsNaN(Upots[tariff.GetConsumerNum() - 1]))
                    {
                        continue;
                    }
                    if (double.IsNaN(Vpots[tariff.GetProducerNum() - 1]))
                    {
                        Vpots[tariff.GetProducerNum() - 1] = tariff.Rate - Upots[tariff.GetConsumerNum() - 1];
                    }
                    else
                    {
                        Upots[tariff.GetConsumerNum() - 1] = tariff.Rate - Vpots[tariff.GetProducerNum() - 1];
                    }
                }
            }
            foreach (Tariff tariff in tariffs)
            {
                if (double.IsNaN(tariff.Potential))
                {
                    tariff.SetPotential(Upots[tariff.GetConsumerNum() - 1] + Vpots[tariff.GetProducerNum() - 1]);
                }
            }
        }

        private static double[] GetNaNArray(int length)
        {
            double[] array = new double[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = double.NaN;
            }
            return array;
        }

        public static void ShowResultSum()
        {
            List<Tariff> filledTariffs = GetFilledTariffs();
            double sum = 0;
            foreach (Tariff tariff in filledTariffs)
            {
                sum += tariff.Rate * tariff.Amount;
            }
            MessageBox.Show("Итоговая сумма: " + sum);
        }
    }
}
