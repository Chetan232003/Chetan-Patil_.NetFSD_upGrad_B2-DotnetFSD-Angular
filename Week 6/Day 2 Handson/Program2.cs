using System;

namespace DiscountSystem
{
    interface IDiscountStrategy
    {
        double CalculateDiscount(double amount);
    }

    class RegularCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.1;
        }
    }

    class PremiumCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.2;
        }
    }

    class VipCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.3;
        }
    }

    class DiscountCalculator
    {
        public double GetFinalPrice(double amount, IDiscountStrategy strategy)
        {
            double discount = strategy.CalculateDiscount(amount);
            return amount - discount;
        }
    }

    class Program2
    {
        static void Main(string[] args)
        {
            double amount = 1000;

            DiscountCalculator calculator = new DiscountCalculator();

            IDiscountStrategy regular = new RegularCustomerDiscount();
            IDiscountStrategy premium = new PremiumCustomerDiscount();
            IDiscountStrategy vip = new VipCustomerDiscount();

            Console.WriteLine("Regular Customer Final Price: " +
                calculator.GetFinalPrice(amount, regular));

            Console.WriteLine("Premium Customer Final Price: " +
                calculator.GetFinalPrice(amount, premium));

            Console.WriteLine("VIP Customer Final Price: " +
                calculator.GetFinalPrice(amount, vip));
        }
    }
}