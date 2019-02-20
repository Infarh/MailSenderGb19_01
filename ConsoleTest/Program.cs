using System;

namespace ConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var report = new Report
            {
                StrData = "My string data!",
                IntData = 42
            };

            report.CreatePackage("report.docx");

            Console.ReadLine();
        }
    }
}
