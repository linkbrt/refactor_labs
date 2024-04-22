namespace RLCExamples01 {
    // Класс, который представляет данные о товаре
    public class Goods {
        protected readonly string _title;
        public IBonusStrategy bonusStrategy;
        public IDiscountStrategy discountStrategy;

        public Goods(string title, IBonusStrategy bonusStrategy, IDiscountStrategy discountStrategy) {
            _title = title;
            this.bonusStrategy = bonusStrategy;
            this.discountStrategy = discountStrategy;
        }

        public string getTitle() {
            return _title;
        }
        public int getBonus(int qty, double price) {
            BonusContext bonusContext = new BonusContext(bonusStrategy);
            return bonusContext.ExecuteOperation(qty, price);
        }
        public (double, double) getDiscount(Customer customer, int qty, double price) {
            DiscountContext discountContext = new DiscountContext(discountStrategy);
            return discountContext.ExecuteOperation(customer, qty, price);
        }
    }
}
