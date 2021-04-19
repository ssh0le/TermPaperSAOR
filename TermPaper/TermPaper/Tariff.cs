using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermPaper
{
    public class Tariff
    {
        private const int Default = -1;
        public Producer Producer;
        public Consumer Consumer;
        public double Rate;
        public int Amount;

        public Tariff(Producer producer, Consumer consumer, double rate)
        {
            Producer = producer;
            Consumer = consumer;
            Rate = rate;
            this.SetDefault();
        }

        public void SetAmount(int amount)
        {
            Amount = amount;
        }

        public void SetDefault()
        {
            Amount = Default;
        }

        public int GetConsumerNum()
        {
            return Consumer.Number;
        }

        public int GetProducerNum()
        {
            return Producer.Number;
        }
    }
}
