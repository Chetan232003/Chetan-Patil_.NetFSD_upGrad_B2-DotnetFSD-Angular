using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_2_Week_6
{
    internal class Problem1
    {
        public static async Task Main(string[] args)
        {

            Console.WriteLine("Application Started: ");
            Task log1 = WriteLogAsync("User Loged in");
            Task log2 = WriteLogAsync("Data Locked");
            Task log3 = WriteLogAsync("Button Clicked");

            await Task.WhenAll(log1, log2, log3);

            Console.WriteLine("Task are completely successfully ");
        }

        async public static Task WriteLogAsync(string message)
        {

           Console.WriteLine($"Start Writting massage : {message}");
            await Task.Delay(1000);

            Console.WriteLine("Finish");
        }
    }
}
