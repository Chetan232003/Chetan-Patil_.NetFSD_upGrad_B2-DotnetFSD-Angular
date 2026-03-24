using System;
using System.Threading;
using System.Threading.Tasks;

class Program3
{
    static void Main(string[] args)
    {
        Console.WriteLine("Report Generation Started...\n");

        Task task1 = Task.Run(() => GenerateSalesReport());
        Task task2 = Task.Run(() => GenerateInventoryReport());
        Task task3 = Task.Run(() => GenerateCustomerReport());

       
        Task.WaitAll(task1, task2, task3);

        Console.WriteLine("\nAll Reports Generated Successfully!");
        Console.ReadLine();
    }

    static void GenerateSalesReport()
    {
        Console.WriteLine("Sales Report Started...");
        Thread.Sleep(2000); 
        Console.WriteLine("Sales Report Completed!");
    }

    static void GenerateInventoryReport()
    {
        Console.WriteLine("Inventory Report Started...");
        Thread.Sleep(3000);
        Console.WriteLine("Inventory Report Completed!");
    }

    static void GenerateCustomerReport()
    {
        Console.WriteLine("Customer Report Started...");
        Thread.Sleep(2500);
        Console.WriteLine("Customer Report Completed!");
    }
}