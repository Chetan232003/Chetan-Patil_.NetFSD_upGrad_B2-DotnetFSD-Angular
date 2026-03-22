using System;
using System.IO;

class Program2

{
    static void Main()
    {
        try
        {
            Console.Write("Enter folder path: ");
            string path = Console.ReadLine();

            DirectoryInfo dir = new DirectoryInfo(path);

            if (!dir.Exists)
            {
                Console.WriteLine("Invalid directory!");
                return;
            }

            FileInfo[] files = dir.GetFiles();

            foreach (var file in files)
            {
                Console.WriteLine($"Name: {file.Name}");
                Console.WriteLine($"Size: {file.Length} bytes");
                Console.WriteLine($"Created: {file.CreationTime}");
                Console.WriteLine("----------------------");
            }

            Console.WriteLine("Total Files: " + files.Length);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}