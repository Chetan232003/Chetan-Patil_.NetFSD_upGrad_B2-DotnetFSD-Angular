using System;

class EmployeeBonus
{
    static void Main()
    {
        Console.WriteLine("Employee Bonus Calculator");

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Salary: ");
        double salary = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Experience (years): ");
        int exp = Convert.ToInt32(Console.ReadLine());

        double bonusRate;

        // Using if-else for bonus rule
        if (exp < 2)
        {
            bonusRate = 0.05;
        }
        else if (exp >= 2 && exp <= 5)
        {
            bonusRate = 0.10;
        }
        else
        {
            bonusRate = 0.15;
        }

        // Using ternary operator
        double bonus = salary > 0 ? salary * bonusRate : 0;

        double finalSalary = salary + bonus;

        Console.WriteLine("\nEmployee: " + name);
        Console.WriteLine("Bonus: " + bonus.ToString("C"));
        Console.WriteLine("Final Salary: " + finalSalary.ToString("C"));
    }
}