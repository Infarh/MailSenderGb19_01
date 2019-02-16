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
            //TPLTest.Test();
            TaskTest.Test(); 

            Console.WriteLine("Основная программа завершена");
            Console.ReadLine();
            Console.WriteLine("Главный поток завершён");
        }
    }
}
