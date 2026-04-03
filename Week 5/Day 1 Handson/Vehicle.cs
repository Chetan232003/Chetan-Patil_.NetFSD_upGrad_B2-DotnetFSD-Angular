using System;

class Vehicle
{
    public string Brand { get; set; }

    private double rentalRatePerDay;

    public double RentalRatePerDay
    {
        get { return rentalRatePerDay; }
        set
        {
            if (value < 0)
                Console.WriteLine("Invalid rate!");
            else
                rentalRatePerDay = value;
        }
    }

    public virtual double CalculateRental(int days)
    {
        if (days <= 0)
        {
            Console.WriteLine("Invalid days!");
            return 0;
        }

        return RentalRatePerDay * days;
    }
}

class Car : Vehicle
{
    public override double CalculateRental(int days)
    {
        double total = base.CalculateRental(days);
        return total + 500;
    }
}

class Bike : Vehicle
{
    public override double CalculateRental(int days)
    {
        double total = base.CalculateRental(days);
        return total - (total * 0.05); 
    }
    class Program
    {
        static void Main()
        {
            Vehicle v = new Car() { Brand = "Toyota", RentalRatePerDay = 2000 };

            Console.WriteLine("Total Rental = " + v.CalculateRental(3));
        }
    }
}