using System;

class BankAccount
{
    private string accountNumber;
    private double balance;

    public string AccountNumber
    {
        get { return accountNumber; }
        set { accountNumber = value; }
    }

    public double Balance
    {
        get { return balance; }
        private set { balance = value; } 
    }

    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid deposit amount!");
            return;
        }

        Balance += amount;
        Console.WriteLine("Deposited: " + amount);
        Console.WriteLine("Current Balance: " + Balance);
    }

    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid withdrawal amount!");
            return;
        }

        if (amount > Balance)
        {
            Console.WriteLine("Insufficient balance!");
            return;
        }

        Balance -= amount;
        Console.WriteLine("Withdrawn: " + amount);
        Console.WriteLine("Current Balance: " + Balance);
    }

    class Program
    {
        static void Main()
        {
            BankAccount acc = new BankAccount();
            acc.AccountNumber = "12345";

            acc.Deposit(5000);
            acc.Withdraw(2000);
        }
    }
}