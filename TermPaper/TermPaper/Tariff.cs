using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermPaper
{
    public class Tariff
    {
        public const int Default = -1;
        public const int Empty = 0;
        public Producer Producer;
        public Consumer Consumer;
        public double Rate;
        public int Amount;
        public double Potential;

        public Tariff(Producer producer, Consumer consumer, double rate)
        {
            Producer = producer;
            Consumer = consumer;
            Rate = rate;
            this.SetDefaultAmount();
            ClearPotential();
        }

        public void SetAmount(int amount)
        {
            Amount = amount;
        }

        public void SetDefaultAmount()
        {
            Amount = Default;
        }

        public void SetEmptyAmount()
        {
            Amount = Empty;
        }

        public int GetConsumerNum()
        {
            return Consumer.Number;
        }

        public int GetProducerNum()
        {
            return Producer.Number;
        }

        
        public void ClearPotential()
        {
            Potential = double.NaN;
        }

        public void SetPotential(double value)
        {
            Potential = value;
        }
    }
}
