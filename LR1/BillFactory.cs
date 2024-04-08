using RLCExamples01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1 {
    public class BillFactory {
        IFileSource contentFile;
        public BillFactory(IFileSource fileSource)
        {
            this.contentFile = fileSource;
        }
        public string[] parseConfigFile(string filename)
        {
            TextReader reader = new StringReader(filename);
            string line = reader.ReadLine();
            List<string> bonuses = new List<string>();
            while (line != null)
            {
                if (line == "#BONUS") {
                    while (line != "####")
                    {
                        line = reader.ReadLine();
                        bonuses.Add(line);
                    }
                }
                line = reader.ReadLine();
            }
            return bonuses.ToArray();
        }
        public string CreateBill(TextReader sr) {
            // read customer
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
