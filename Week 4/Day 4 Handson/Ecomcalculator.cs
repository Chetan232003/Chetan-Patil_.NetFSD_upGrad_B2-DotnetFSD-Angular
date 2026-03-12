using System;


namespace Day_4_Handson
{
    internal class Ecomcalculator
    {

        public double CalculateFinalAmount(double price, int quantity, double discount = 0, double shipping = 50)
        {
            double total = price * quantity;
            double discountAmount = total * discount / 100;
            double finalAmount = total - discountAmount + shipping;

            return finalAmount;
        }

        static void Main(string[] args)
        {
            Ecomcalculator shop = new Ecomcalculator();

            Console.Write("Enter Product Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            
            double amount = shop.CalculateFinalAmount(price, quantity);

            Console.WriteLine("Final Payable Amount: " + amount);
        }
    }
}
