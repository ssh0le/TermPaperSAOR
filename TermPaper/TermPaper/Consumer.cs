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
