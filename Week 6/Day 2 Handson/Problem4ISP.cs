using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4th
{

    interface IPrinter
    {
        public void Print(string text);
    }
    interface IScanner
    {
        public void Scan(string text);
    }
    interface IFax
    {
        public void fax(string text);
    }

    class BasicPrinter : IPrinter
    {
        public void Print(string text)
        {
            Console.WriteLine("This is the basic :"+text);
        }
    }

    class AdvancedPrinter : IPrinter, IFax, IScanner
    {
        public void fax(string text)
        {
            Console.WriteLine("This is the Advance : " + text);
        }
        public void Print(string text)
        {
            Console.WriteLine("This is the Advance : " + text);

        }

        public void Scan(string text)
        {
            Console.WriteLine("This is the Advance : " + text);

        }
    }
    internal class Problem4ISP
    {
        public static void Main(string[] args)
        {

            IPrinter printer = new BasicPrinter();
            Console.WriteLine("Basic Printer");
            printer.Print("Printer");

            Console.WriteLine("Advanced Printer");

            AdvancedPrinter advancedPrinter = new AdvancedPrinter();
            advancedPrinter.Print("Printer");
            advancedPrinter.Scan("Scanner");
            advancedPrinter.fax("Fax Machine");
        }
    }

}
