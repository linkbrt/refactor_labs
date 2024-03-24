using RLCExamples01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1 {
    public class BillFactory {
        public static string CreateBill(TextReader sr) {
            // read customer
            ContentFile contentFile = new ContentFile();
            contentFile.SetSource(sr);
            string name = contentFile.GetCustomer();
            // read bonus
            int bonus = contentFile.GetBonus();
            Customer customer = new Customer(name, bonus);
            IView view = new TxtView();
            Bill b = new Bill(customer, view);
            // read goods count
            int goodsQty = contentFile.GetGoodsCount();
            Goods[] g = new Goods[goodsQty];
            for (int i = 0; i < g.Length; i++) {
                g[i] = contentFile.GetNextGood();
            }
            // read items count
            int itemsQty = contentFile.GetItemsCount();
            for (int i = 0; i < itemsQty; i++) {
                // Пропустить комментарии
                Item item = contentFile.GetNextItem(g);
                b.addGoods(item);
            }
            BillGenerator billGenerator = new BillGenerator(customer, view, b);
            string bill = billGenerator.statement();
            return bill;
        }
    }
}
