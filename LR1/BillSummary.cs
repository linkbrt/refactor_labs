using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCExamples01
{
    public class BillSummary
    {
        public double TotalAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal CustomerName { get; set; }
        public int TotalBonus { get; set; }
        public List<ItemSummary> items = new();
    }
}
