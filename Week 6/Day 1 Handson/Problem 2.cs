using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problme_2
{
    internal class Problem_2
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("Calculator Started :");

            Console.Write("Enter the name Of Product: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the Price:");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the Discount percent");
            double discount = Convert.ToDouble(Console.ReadLine());

            var result = DiscountCalculator(name,price,discount);
            Console.WriteLine("Final Price :" + result);

        }

        public static double DiscountCalculator(string nameofProduct, double priceofProduct, double productdiscount) {

            
            double finalprice = priceofProduct - priceofProduct * productdiscount / 100;
            return finalprice;


        }
    }
}
