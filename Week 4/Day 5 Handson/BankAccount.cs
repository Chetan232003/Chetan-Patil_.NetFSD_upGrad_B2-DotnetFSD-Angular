using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount_Problem
{
    internal class BankAccount
    {

        private double balance;

        public void deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine("Deposit balance : " + amount);
            }
            else
            {
                Console.WriteLine("Insufficient Ammount");
            }

        }
        public void Withdraw(double amount)
        {
            if (amount > 0)
            {
                balance -= amount;
                Console.WriteLine("Withdraw Ammount : " + amount);
            }
            else
            {
                Console.WriteLine("Enter the Appropriate Ammount > 0");
            }
        }
        public double getbalance()
        {
            return balance;
        }

    }

    class Program
    {
        public static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount();
            bankAccount.deposit(1000);
            bankAccount.Withdraw(100);

            Console.WriteLine("Current Balance :"+bankAccount.getbalance());
        }
    }
}
