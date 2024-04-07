using LR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCExamples01
{
    public class FileSourceFactory
    {
        public static IFileSource Create(string filename)
        {
            string extension = filename.Split('.')[1];
            if (extension == "yaml") { return new YamlFileSource(); }
            if (extension == "csv") { return new CsvFileSource(); }

            return null;
        }
    }
}
