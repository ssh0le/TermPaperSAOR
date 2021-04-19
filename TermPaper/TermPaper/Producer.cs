using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermPaper
{
    public class Producer
    {
        public int Number;
        private static int Amount;
        public int Stock;

        public Producer(int stock)
        {
            Number = Amount++;
            Stock = stock;
        }

        public static void Reset()
        {
            Amount = 1;
        }
    }
}
