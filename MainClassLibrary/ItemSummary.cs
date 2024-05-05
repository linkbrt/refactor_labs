using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCExamples01
{
    public class ItemSummary
    {
        public string name;
        public double price;
        public double qty;
        public double sum;
        public double discount;
        public int bonus;
        public double amount;
        public ItemSummary(Item item)
        {
            name = item.getGoods().getTitle();
            price = item.getPrice();
            qty = item.getQuantity();
            sum = item.getSum();
            bonus = item.getBonus();
        }
    }
}
