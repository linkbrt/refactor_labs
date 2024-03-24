using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using RLCExamples01;
using LR1;

namespace RLCExamples01 {
    public class Program {
        static void Main(string[] args)
        {
            //UsageExample.Example();
            string filename = "BillInfo.yaml";
            if (args.Length == 1)
                filename = args[0];
            FileStream fs = new FileStream(filename, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string bill = BillFactory.CreateBill(sr);
            Console.WriteLine(bill);
        }
    }
}