using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCExamples01
{
    public interface IFileSource
    {
        public void SetSource(TextReader tr);
        public string GetCustomer();
        public int GetBonus();
        public int GetGoodsCount();
        public Goods GetNextGood();
        public int GetItemsCount();
        public Item GetNextItem(Goods[] g);
        public string GetNextLine();
    }
}
