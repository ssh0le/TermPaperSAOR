using System;
using System.Collections.Generic;
using System.Linq;

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
        private static int ProducerAmount = 4;
        private static int ConsumerAmount = 5;
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
                    if (horIndex + 1 >= tariffs.GetLength(1) && verIndex + 1 >= tariffs.GetLength(0))
                    {
                        break;
                    }
                    if (verIndex + 1 < tariffs.GetLength(0))
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

        public static void InitializeTariffs(string[,] matrix, string[] tractorAmount)
        {
            InitializeItems(matrix, tractorAmount);
            tariffs = new Tariff[consumers.Count + 1, producers.Count + 1];
            double MaxRate = FindMaxRate(matrix);
            for (int i = 0; i < ConsumerAmount; i++)
            {
                for (int j = 0; j < ProducerAmount; j++)
                {
                    if (double.TryParse(matrix[i, j], out double rate))
                    {
                        if (rate > 0)
                        {
                            tariffs[i, j] = new Tariff(producers[j], consumers[i], rate);
                        }
                        else
                        {
                            tariffs[i, j] = new Tariff(producers[j], consumers[i], MaxRate + AddToMax);
                        }
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

        private static double FindMaxRate(string[,] matrix)
        {
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
            return MaxRate;
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

        private static void InitializeItems(string[,] matrix, string[] tractorAmount)
        {
            Consumer.Reset();
            Producer.Reset();
            consumers = new List<Consumer>();
            producers = new List<Producer>();
            ConsumerAmount = matrix.GetLength(0) - 1;
            ProducerAmount = matrix.GetLength(1) - 1;
            for (int i = 0; i < ProducerAmount; i++)
            {
                producers.Add(new Producer(int.Parse(matrix[matrix.GetLength(0) - 1, i]) * int.Parse(tractorAmount[i])));
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

        public static void SolveProblem(string[,] matrix, string[] tractorAmount)
        {
            InitializeTariffs(matrix, tractorAmount);
            NorthWestMethod();
            FindOptimalSolutuion();
        }

        public static void FindOptimalSolutuion()
        {
            SetPotentials();
            Tariff perspectiveTariff = FindPerspectiveTariff();
            if (perspectiveTariff == null)
            {
                return;
            }
            do
            {
                perspectiveTariff.SetEmptyAmount();
                List<Tariff> filledTariffs = GetFilledTariffs();
                List<Tariff> circuitNodes = GetTariffContour(perspectiveTariff, filledTariffs);
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
                        if (IsNecessaryTariff(circuitNodes[i]))
                        {
                            circuitNodes[i].SetEmptyAmount();
                        }
                        else
                        {
                            circuitNodes[i].SetDefaultAmount();
                        }
                    }
                    else
                    {
                        circuitNodes[i].SetAmount(circuitNodes[i].Amount - amount);
                    }
                }
                SetPotentials();
                perspectiveTariff = FindPerspectiveTariff();
                RemoveUnnecessaryTariffs();
                Displayer?.Invoke();
            }
            while (perspectiveTariff != null);
            ResizeTariffArray(ref tariffs, ConsumerAmount, ProducerAmount);
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

        private static Tariff FindPerspectiveTariff()
        {
            Tariff newTariff = null;
            double maxDifference = 0;
            foreach (Tariff tariff in GetUnfilledTariffs())
            {
                double tariffDifference = tariff.Potential - tariff.Rate;
                if (tariffDifference > maxDifference)
                {
                    maxDifference = tariffDifference;
                    newTariff = tariff;
                }
            }
            return newTariff;
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

        private static List<Tariff> GetUnfilledTariffs()
        {
            List<Tariff> filledTariffs = new List<Tariff>();
            foreach (Tariff tariff in tariffs)
            {
                if (tariff.Amount == Tariff.Default)
                {
                    filledTariffs.Add(tariff);
                }
            }
            return filledTariffs;
        }

        public static void SetPotentials()
        {
            List<Tariff> filledTariffs = GetFilledTariffs();
            ClearPotentials();
            Upots = GetNaNArray(tariffs.GetLength(0));
            Vpots = GetNaNArray(tariffs.GetLength(1));
            int startIndex = 0;
            double Vpot = Math.Floor(filledTariffs[startIndex].Rate / 2);
            Vpots[filledTariffs[startIndex].GetProducerNum() - 1] = Vpot;
            Upots[filledTariffs[startIndex].GetConsumerNum() - 1] = filledTariffs[startIndex].Rate - Vpot;
            while (filledTariffs.Count > 0)
            {
                foreach (Tariff tariff in filledTariffs)
                {
                    if (!double.IsNaN(Vpots[tariff.GetProducerNum() - 1]) && !double.IsNaN(Upots[tariff.GetConsumerNum() - 1]))
                    {
                        filledTariffs.Remove(tariff);
                        break;
                    }
                    if (double.IsNaN(Vpots[tariff.GetProducerNum() - 1]) && !double.IsNaN(Upots[tariff.GetConsumerNum() - 1]))
                    {
                        Vpots[tariff.GetProducerNum() - 1] = tariff.Rate - Upots[tariff.GetConsumerNum() - 1];
                        filledTariffs.Remove(tariff);
                        break;
                    }
                    if (!double.IsNaN(Vpots[tariff.GetProducerNum() - 1]) && double.IsNaN(Upots[tariff.GetConsumerNum() - 1]))
                    {
                        Upots[tariff.GetConsumerNum() - 1] = tariff.Rate - Vpots[tariff.GetProducerNum() - 1];
                        filledTariffs.Remove(tariff);
                        break;
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

        private static void ClearPotentials()
        {
            foreach (Tariff tariff in tariffs)
            {
                tariff.ClearPotential();
                if (tariff.Amount != Tariff.Default)
                {
                    tariff.SetPotential(tariff.Rate);
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

        private static bool IsNecessaryTariff(Tariff tariff)
        {
            List<Tariff> tariffs = GetFilledTariffs();
            tariffs.Remove(tariff);
            return CheckPotentials(tariffs);
        }

        private static bool CheckPotentials(List<Tariff> tariffList)
        {
            bool[] Upots, Vpots;
            Vpots = GetArrayFilledByFalse(tariffs.GetLength(1));
            Upots = GetArrayFilledByFalse(tariffs.GetLength(0));
            int startIndex = 0;
            Vpots[tariffList[startIndex].GetProducerNum() - 1] = true;
            Upots[tariffList[startIndex].GetConsumerNum() - 1] = true;
            tariffList.RemoveAt(startIndex);
            int j = 1;
            for (int i = 0; i < j && tariffList.Count > 0; i++)
            {
                foreach (Tariff tariff in tariffList)
                {
                    if (Vpots[tariff.GetProducerNum() - 1])
                    {
                        Upots[tariff.GetConsumerNum() - 1] = true;
                        j++;
                    }
                    if (Upots[tariff.GetConsumerNum() - 1])
                    {
                        Vpots[tariff.GetProducerNum() - 1] = true;
                        j++;
                    }
                }
                for (int k = tariffList.Count - 1; k >= 0; k--)
                {
                    bool check = Upots[tariffList[k].GetConsumerNum() - 1] && Vpots[tariffList[k].GetProducerNum() - 1];
                    if (check)
                    {
                        tariffList.RemoveAt(k);
                    }
                }
            }
            for (int i = 0; i < Vpots.Length; i++)
            {
                if (!Vpots[i])
                {
                    return !Vpots[i];
                }
            }
            for (int i = 0; i < Upots.Length; i++)
            {
                if (!Upots[i])
                {
                    return !Upots[i];
                }
            }
            return false;
        }

        private static bool[] GetArrayFilledByFalse(int length)
        {
            bool[] array = new bool[length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = false;
            }
            return array;
        }

        private static void RemoveUnnecessaryTariffs()
        {
            List<Tariff> filledTariffs = GetFilledTariffs();
            foreach (Tariff tariff in filledTariffs)
            {
                if (tariff.Amount == Tariff.Empty && !IsNecessaryTariff(tariff))
                {
                    tariff.SetDefaultAmount();
                }
            }
        }

        public static double GetResultSum()
        {
            List<Tariff> filledTariffs = GetFilledTariffs();
            double sum = 0;
            foreach (Tariff tariff in filledTariffs)
            {
                sum += tariff.Rate * tariff.Amount;
            }
            return sum;
        }

    }
}
