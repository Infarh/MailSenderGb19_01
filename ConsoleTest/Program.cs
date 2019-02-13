using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Mail;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadTest.Test();
            
            Console.ReadLine();
            Console.WriteLine("Главный поток завершён");

            //System.Collections.Concurrent.BlockingCollection<>
            //System.Collections.Concurrent.ConcurrentBag<>
            //System.Collections.Concurrent.ConcurrentDictionary<>
        }
    }
}
