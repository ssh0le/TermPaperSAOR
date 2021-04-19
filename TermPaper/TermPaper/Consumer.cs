using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermPaper
{
    public class Consumer
    {
        public int Number;
        private static int Amount;
        public int Demand;

        public Consumer(int demand)
        {
            Number = Amount++;
            Demand = demand;
        }

        public static void Reset()
        {
            Amount = 1;
        }
    }
}
