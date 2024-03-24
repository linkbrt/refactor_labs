using RLCExamples01;

namespace LR1 {
    internal class GoodsFactory {
        static public Goods? Create(string id, string name) {
            if (id == "REG") { return new RegularGoods(name); }
            if (id == "SAL") { return new SaleGoods(name); }
            if (id == "SPO") { return new SpecialGoods(name); }

            return null;
        }
    }
}
