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
            string filename = "BillInfo.csv";
            if (args.Length == 1)
                filename = args[0];
            FileStream fs = new FileStream(filename, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            BillFactory billFactory = new BillFactory(
                fileSource: FileSourceFactory.Create(filename)
            );

            string bill = billFactory.CreateBill(sr);
            Console.WriteLine(bill);
        }
    }
}