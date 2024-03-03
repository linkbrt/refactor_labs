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
        string getItemString(Item item, double discount, double thisAmount, int bonus)
        {
            return "\t" + item.getGoods().getTitle() + "\t" +
                   "\t" + item.getPrice() + "\t" + item.getQuantity() +
                   "\t" + (item.getQuantity() * item.getPrice()).ToString() +
                   "\t" + discount.ToString() + "\t" + thisAmount.ToString() +
                   "\t" + bonus.ToString() + "\n";
        }
        public string oldStatement()
        {
            List<Item>.Enumerator items = _items.GetEnumerator();
            string result = "Счет для " + _customer.getName() + "\n";
            result += "\t" + "Название" + "\t" + "Цена" +
            "\t" + "Кол-во" + "Стоимость" + "\t" + "Скидка" +
            "\t" + "Сумма" + "\t" + "Бонус" + "\n";
            while (items.MoveNext())
            {
                double thisAmount = 0;
                double discount = 0;
                int bonus = 0;
                Item each = (Item)items.Current;
                //определить сумму для каждой строки
                switch (each.getGoods().getPriceCode())
                {
                    case Goods.REGULAR:
                        if (each.getQuantity() > 2)
                            discount =
                           (each.getQuantity() * each.getPrice()) * 0.03; // 3%
                        bonus =
                       (int)(each.getQuantity() * each.getPrice() * 0.05);
                        break;
                    case Goods.SPECIAL_OFFER:
                        if (each.getQuantity() > 10)
                            discount =
                           (each.getQuantity() * each.getPrice()) * 0.005; // 0.5%
                        break;
                    case Goods.SALE:
                        if (each.getQuantity() > 3)
                            discount =
                           (each.getQuantity() * each.getPrice()) * 0.01; // 0.1%
                        bonus =
                       (int)(each.getQuantity() * each.getPrice() * 0.01);
                        break;
                }
                // сумма
                thisAmount = each.getQuantity() * each.getPrice();
                // используем бонусы
                if ((each.getGoods().getPriceCode() ==
                Goods.REGULAR) && each.getQuantity() > 5)
                    discount +=
                   _customer.useBonus((int)(each.getQuantity() * each.getPrice()));
                if ((each.getGoods().getPriceCode() ==
                Goods.SPECIAL_OFFER) && each.getQuantity() > 1)
                    discount =
                   _customer.useBonus((int)(each.getQuantity() * each.getPrice()));
                // учитываем скидку
                thisAmount =
               each.getQuantity() * each.getPrice() - discount;
                //показать результаты
                result += "\t" + each.getGoods().getTitle() + "\t" +
                "\t" + each.getPrice() + "\t" + each.getQuantity() +
                "\t" + (each.getQuantity() * each.getPrice()).ToString() +
                "\t" + discount.ToString() + "\t" + thisAmount.ToString() +
                "\t" + bonus.ToString() + "\n";
                totalAmount += thisAmount;
                totalBonus += bonus;
            }
            //добавить нижний колонтитул
            result += "Сумма счета составляет " +
           totalAmount.ToString() + "\n";
            result += "Вы заработали " +
           totalBonus.ToString() + " бонусных баллов";
            //Запомнить бонус клиента
            _customer.receiveBonus(totalBonus);
            return result;
        }
    }
}