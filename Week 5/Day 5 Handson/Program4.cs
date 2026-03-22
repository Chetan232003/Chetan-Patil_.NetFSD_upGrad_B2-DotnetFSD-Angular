using System;
using System.IO;

class Program4

{
    static void Main()
    {
        try
        {
            Console.Write("Enter root directory path: ");
            string path = Console.ReadLine();

            DirectoryInfo dir = new DirectoryInfo(path);

            if (!dir.Exists)
            {
                Console.WriteLine("Directory not found!");
                return;
            }

            DirectoryInfo[] directories = dir.GetDirectories();

            foreach (var d in directories)
            {
                FileInfo[] files = d.GetFiles();
                Console.WriteLine($"Folder: {d.Name} | Files: {files.Length}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}