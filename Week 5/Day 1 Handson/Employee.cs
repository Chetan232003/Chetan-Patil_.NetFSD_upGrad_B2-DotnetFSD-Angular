using System;


class Employee
{
    public string Name { get; set; }
    public double BaseSalary { get; set; }

    public virtual double CalculateSalary()
    {
        return BaseSalary;
    }
}

class Manager : Employee
{
    public override double CalculateSalary()
    {
        return BaseSalary + (BaseSalary * 0.20);
    }
}

class Developer : Employee
{
    public override double CalculateSalary()
    {
        return BaseSalary + (BaseSalary * 0.10);
    }
}

class Program
{
    static void Main()
    {
        Employee emp1 = new Manager() { Name = "A", BaseSalary = 50000 };
        Employee emp2 = new Developer() { Name = "B", BaseSalary = 50000 };

        Console.WriteLine("Manager Salary = " + emp1.CalculateSalary());
        Console.WriteLine("Developer Salary = " + emp2.CalculateSalary());
    }
}