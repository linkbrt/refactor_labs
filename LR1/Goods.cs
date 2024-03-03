namespace RLCExamples01 {
    // Класс, который представляет данные о товаре
    public class Goods {
        protected readonly string _title;

        public Goods(string title) {
            _title = title;
        }
        public string getTitle() {
            return _title;
        }
        virtual public int getBonus(int qty, double price) {
            return default;
        }
        virtual public (double, double) getDiscount(Customer customer, int qty, double price) {
            return (default, default);
        }
    }
    public class RegularGoods : Goods {
        public RegularGoods(string title) : base(title) {
        }
        public override int getBonus(int qty, double price) {
            return (int)(qty * price * 0.05);
        }
        public override (double, double) getDiscount(Customer customer, int qty, double price) {
            double discount = 0;
            double usedBonus = 0;
            if (qty > 2) {
                discount = qty * price * 0.03;
            }
            if (qty > 5) {
                usedBonus = customer.getUsedBonus((qty * price) - discount);
            }
            return (discount, usedBonus);
        }
    }
    public class SaleGoods : Goods {
        public SaleGoods(string title) : base(title) {
        }
        public override int getBonus(int qty, double price) {
            return (int)(qty * price * 0.01);
        }
        public override (double, double) getDiscount(Customer customer, int qty, double price) {
            double discount = 0;
            double usedBonus = 0;
            if (qty > 3) {
                discount = qty * price * 0.01;
            }
            return (discount, usedBonus);
        }
    }
    public class SpecialGoods : Goods {
        public SpecialGoods(string title) : base(title) {
        }
        public override (double, double) getDiscount(Customer customer, int qty, double price) {
            double discount = 0;
            double usedBonus = 0;
            if (qty > 10) {
                discount = qty * price * 0.005;
            }
            if (qty > 1) {
                usedBonus = customer.getUsedBonus((qty * price) - discount);
            }
            return (discount, usedBonus);
        }
    }
}
