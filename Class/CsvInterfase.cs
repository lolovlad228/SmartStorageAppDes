using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SmartSorage.Class
{
    class CsvInterfase
    {

        private readonly string distonary = "D:/SmartSorage/Csv/";
        private string _path;
        public string PathFile {
            get
            {
                return _path;
            }
            set
            {
                if(!File.Exists(Path.Combine(distonary, value + ".csv")))
                    File.Create(Path.Combine(distonary, value + ".csv"));
                _path = Path.Combine(distonary, value + ".csv");
            }
        }

        public void SaveCsv(int? info)
        {
            using(StreamWriter WriteFile = new StreamWriter(_path, true))
            {
                WriteFile.WriteLine(DateTime.Now.ToString() + ";" + info.ToString());
            }
        }
    }
}
