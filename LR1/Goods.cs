namespace RLCExamples01 {
    // Класс, который представляет данные о товаре
    public class Goods {
        public const int REGULAR = 0;
        public const int SALE = 1;
        public const int SPECIAL_OFFER = 2;
        private readonly string _title;
        private int _priceCode;

        public Goods(string title, int priceCode) {
            _title = title;
            _priceCode = priceCode;
        }
        public int getPriceCode() {
            return _priceCode;
        }
        public void setPriceCode(int arg) {
            _priceCode = arg;
        }
        public string getTitle() {
            return _title;
        }
        public int getBonus(Item item) {
            int bonus = 0;
            switch (item.getGoods().getPriceCode()) {
                case REGULAR:
                    bonus = (int)(item.getSum() * 0.05);
                    break;
                case SPECIAL_OFFER:
                    break;
                case SALE:
                    bonus = (int)(item.getSum() * 0.01);
                    break;
            }
            return bonus;
        }
        public (double, double) getDiscount(Customer customer, Item item) {
            double discount = 0;
            double usedBonus = 0;
            switch (item.getGoods().getPriceCode()) {
                case REGULAR:
                    if (item.getQuantity() > 2)
                        discount = item.getSum() * 0.03; // 3%
                    if (item.getQuantity() > 5)
                        usedBonus = customer.getUsedBonus(item, discount);
                    break;
                case SPECIAL_OFFER:
                    if (item.getQuantity() > 10)
                        discount = item.getSum() * 0.005; // 0.5%
                    if (item.getQuantity() > 1)
                        usedBonus = customer.getUsedBonus(item, discount);
                    break;
                case SALE:
                    if (item.getQuantity() > 3)
                        discount = item.getSum() * 0.01; // 1%
                    break;
            }
            return (discount, usedBonus);
        }
    }
}
