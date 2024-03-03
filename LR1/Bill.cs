namespace RLCExamples01
{
    public class Bill
    {
        private List<Item> _items;
        private Customer _customer;
        public double totalAmount = 0;
        public int totalBonus = 0;
        public Bill(Customer customer)
        {
            this._customer = customer;
            this._items = new List<Item>();
        }
        public void addGoods(Item arg)
        {
            _items.Add(arg);
        }
        public string statement()
        {
            List<Item>.Enumerator items = _items.GetEnumerator();
            string result = getHeader();
            while (items.MoveNext())
            {
                Item each = items.Current;
                (double discount, double usedBonus) = each.getDiscount(_customer);
                int bonus = each.getBonus();
                double sumWithDiscount = each.getSum() - discount;
                double thisAmount = sumWithDiscount - usedBonus;
                totalAmount += thisAmount;
                totalBonus += bonus;
                result += getItemString(each, discount, thisAmount, bonus);
            }
            _customer.receiveBonus(totalBonus);
            result += getFooter();
            return result;
        }
        string getHeader()
        {
            return "Счет для " + _customer.getName() + "\n" +
                   "\t" + "Название" + "\t" + "Цена" +
                   "\t" + "Кол-во" + "Стоимость" + "\t" + "Скидка" +
                   "\t" + "Сумма" + "\t" + "Бонус" + "\n";
        }
        string getFooter()
        {
            return "Сумма счета составляет " + totalAmount.ToString() + "\n" +
                    "Вы заработали " + totalBonus.ToString() +
                    " бонусных баллов";
        }
        string getItemString(Item item, double discount, 
                             double thisAmount, int bonus)
        {
            return "\t" + item.getGoods().getTitle() + "\t" +
                   "\t" + item.getPrice() + "\t" + item.getQuantity() +
                   "\t" + (item.getQuantity() * item.getPrice()).ToString() +
                   "\t" + discount.ToString() + "\t" + thisAmount.ToString() +
                   "\t" + bonus.ToString() + "\n";
        }
    }
}