using System;
using System.Diagnostics;
using System.IO;

class Problem5
{
    static void Main(string[] args)
    {
        Trace.Listeners.Add(new TextWriterTraceListener("traceLog.txt"));
        Trace.AutoFlush = true;

        Console.WriteLine("Order Processing Started...\n");

        try
        {
            ValidateOrder();
            ProcessPayment();
            UpdateInventory();
            GenerateInvoice();

            Trace.TraceInformation("Order processed successfully.");
        }
        catch (Exception ex)
        {
            Trace.WriteLine("Error: " + ex.Message);
        }

        Console.WriteLine("Processing Completed. Check traceLog.txt");
        Console.ReadLine();
    }

    static void ValidateOrder()
    {
        Trace.WriteLine("Validating Order...");
    }

    static void ProcessPayment()
    {
        Trace.WriteLine("Processing Payment...");
    }

    static void UpdateInventory()
    {
        Trace.WriteLine("Updating Inventory...");
    }

    static void GenerateInvoice()
    {
        Trace.WriteLine("Generating Invoice...");
    }
}