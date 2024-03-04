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
        public BillSummary Process()
        {
            BillSummary billSummary = new BillSummary();
            List<Item>.Enumerator items = _items.GetEnumerator();
            while (items.MoveNext())
            {
                Item each = items.Current;
                ItemSummary itemSummary = new ItemSummary(each);
                (itemSummary.discount, double usedBonus) = each.getDiscount(_customer);
                double sumWithDiscount = itemSummary.sum - itemSummary.discount;
                itemSummary.amount = sumWithDiscount - usedBonus;
                billSummary.TotalAmount += itemSummary.amount;
                billSummary.TotalBonus += itemSummary.bonus;
                billSummary.items.Add(itemSummary);
            }
            _customer.receiveBonus(totalBonus);
            return billSummary;
        }
        
    }
    public class BillGenerator
    {
        private List<Item> _items;
        private Customer _customer;
        public double totalAmount = 0;
        public int totalBonus = 0;
        IView view;
        Bill bill;
        public BillGenerator(Customer customer, IView view, Bill bill)
        {
            this._customer = customer;
            this._items = new List<Item>();
            this.view = view;
            this.bill = bill;
        }
        public void addGoods(Item arg)
        {
            _items.Add(arg);
        }
        public string statement()
        {
            BillSummary billSummary = bill.Process();
            List<Item>.Enumerator items = _items.GetEnumerator();
            string result = view.getHeader(_customer.getName());
            foreach (ItemSummary billItem in billSummary.items)
            {
                result += view.getItemString(billItem);
            }
            _customer.receiveBonus(totalBonus);
            totalAmount = billSummary.TotalAmount; totalBonus = billSummary.TotalBonus;
            result += view.getFooter(billSummary.TotalAmount, billSummary.TotalBonus);
            return result;
        }

    }
}