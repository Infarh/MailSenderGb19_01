using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTestLib
{
    public class ConsolePrinter
    {
        private string _Prefix = "";

        public string Prefix => _Prefix;

        public ConsolePrinter() { }
        public ConsolePrinter(string Prefix) => _Prefix = Prefix;

        public void Print(string msg)
        {
            //var str = $"{_Prefix}{msg}";
            //var str = string.Format("{0}{1}", _Prefix, msg);

            Console.WriteLine("{0}{1}", _Prefix, msg);
            //Console.WriteLine(string.Format("{0}{1}", _Prefix, msg));
        }
    }
}
