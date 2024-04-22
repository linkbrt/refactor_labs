using LR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCExamples01
{
    internal class CsvFileSource: IFileSource
    {
        TextReader? Reader;
        public CsvFileSource() { }
        public void SetSource(TextReader tr) {
            Reader = tr;
        }
        public string GetCustomer()
        {
            string line = GetNextLine();
            string[] result = line.Split(',');
            return result[1].Trim();
        }
        public int GetBonus()
        {
            string line = GetNextLine();
            string[] result = line.Split(',');
            return Convert.ToInt32(result[1].Trim());
        }
        public int GetGoodsCount()
        {
            string line = GetNextLine();
            string[] result = line.Split(",");
            return Convert.ToInt32(result[1].Trim());
        }
        public Goods GetNextGood()
        {
            string line = GetNextLine();
            string[] result = line.Split(',');
            string type = result[2].Trim();
            return GoodsFactory.Create(type, result[1]);
        }
        public int GetItemsCount()
        {
            string[] result = GetNextLine().Split(',');
            return Convert.ToInt32(result[1].Trim());
        }
        public Item GetNextItem(Goods[] g)
        {
            string[] result = GetNextLine().Split(',');
            int gid = Convert.ToInt32(result[1].Trim());
            double price = Convert.ToDouble(result[2].Trim());
            int qty = Convert.ToInt32(result[3].Trim());
            return new Item(g[gid - 1], qty, price);
        }
        public string GetNextLine()
        {
            string line = Reader.ReadLine();
            while (line.StartsWith("#"))
            {
                line = Reader.ReadLine();
            }
            return line;
        }
    }
}
