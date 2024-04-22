namespace RLCExamples01
{
    public interface IBonusStrategy
    {
        public int Algorithm(int qty, double price);
    }
    class NewYearSaleBonusStrategy : IBonusStrategy
    {
        public int Algorithm(int qty, double price)
        {
            double sum = qty * price;
            if (sum > 2000)
            {
                return (int)(sum * 0.03);
            }
            else
            {
                return 0;
            }
        }
    }
    class NewYearSpecialBonusStrategy : IBonusStrategy
    {
        public int Algorithm(int qty, double price)
        {
            double sum = qty * price;
            if (sum > 3000)
            {
                return (int)(sum * 0.05);
            }
            else
            {
                return 0;
            }
        }
    }
    class RegularBonusStrategy : IBonusStrategy
    {
        public int Algorithm(int qty, double price)
        {
            return (int)(qty * price * 0.05);
        }
    }
    class SaleBonusStrategy : IBonusStrategy
    {
        public int Algorithm(int qty, double price)
        {
            return (int)(qty * price * 0.01);
        }
    }
    class SpecialBonusStrategy : IBonusStrategy
    {
        public int Algorithm(int qty, double price)
        {
            return 0;
        }
    }
    class BonusContext
    {
        private IBonusStrategy _strategy { get; set; }
        public BonusContext(IBonusStrategy strategy)
        {
            _strategy = strategy;
        }
        public int ExecuteOperation(int qty, double price)
        {
            return _strategy.Algorithm(qty, price);
        }
    }
}
