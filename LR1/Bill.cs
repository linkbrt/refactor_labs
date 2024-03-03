namespace RLCExamples01
{
    public class Bill
    {
        private List<Item> _items;
        private Customer _customer;
        public double totalAmount = 0;
        public int totalBonus = 0;
        IView view;
        public Bill(Customer customer, IView view)
        {
            this._customer = customer;
            this._items = new List<Item>();
            this.view = view;
        }
        public void addGoods(Item arg)
        {
            _items.Add(arg);
        }
        public string statement()
        {
            List<Item>.Enumerator items = _items.GetEnumerator();
            string result = view.getHeader(_customer.getName());
            while (items.MoveNext())
            {
                Item each = items.Current;
                (double discount, double usedBonus) = each.getDiscount(_customer);
                int bonus = each.getBonus();
                double sumWithDiscount = each.getSum() - discount;
                double thisAmount = sumWithDiscount - usedBonus;
                totalAmount += thisAmount;
                totalBonus += bonus;
                result += view.getItemString(each, discount, thisAmount, bonus);
            }
            _customer.receiveBonus(totalBonus);
            result += view.getFooter(totalAmount, totalBonus);
            return result;
        }
        
    }
}