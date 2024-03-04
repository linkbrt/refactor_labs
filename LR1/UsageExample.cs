using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RLCExamples01
{
    public class UsageExample
    {
        public static void Example()
        {
            Goods cola = new RegularGoods("Cola");
            Goods pepsi = new SaleGoods("Pepsi");
            Item i1 = new Item(cola, 6, 65);
            Item i2 = new Item(pepsi, 3, 50);
            Customer x = new Customer("test", 10);
            IView view = new TxtView();
            Bill b1 = new Bill(x, view);
            b1.addGoods(i1);
            b1.addGoods(i2);
            BillGenerator billGenerator = new BillGenerator(x, view, b1);
            string bill = billGenerator.statement();

            Console.WriteLine(bill);
        }
    }
}
