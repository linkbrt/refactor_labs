using RLCExamples01;

namespace LR1
{
    public class GoodsFactory
    {
        static public Goods? Create(string id, string name)
        {
            if (false) // NEW YEAR
            {
                if (id == "REG") { return new Goods(name, new RegularBonusStrategy(), new RegularDiscountStrategy()); }
                if (id == "SAL") { return new Goods(name, new NewYearSaleBonusStrategy(), new SaleDiscountStrategy()); }
                if (id == "SPO") { return new Goods(name, new NewYearSpecialBonusStrategy(), new SpecialDiscountStrategy()); }
            }

            if (id == "REG") { return new Goods(name, new RegularBonusStrategy(), new RegularDiscountStrategy()); }
            if (id == "SAL") { return new Goods(name, new SaleBonusStrategy(), new SaleDiscountStrategy()); }
            if (id == "SPO") { return new Goods(name, new SpecialBonusStrategy(), new SpecialDiscountStrategy()); }

            return null;
        }
    }
}
