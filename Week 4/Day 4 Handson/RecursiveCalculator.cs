using System;

namespace Day_4_Handson
{
    internal class RecursiveCalculator
    {
        public int CalculatePower(int baseNum, int exponent)
        {
            if (exponent == 0)
                return 1;

            return baseNum * CalculatePower(baseNum, exponent - 1);
        }

        static void Main(string[] args)
        {
            RecursiveCalculator obj = new RecursiveCalculator();

            Console.Write("Enter Base: ");
            int baseNum = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Exponent: ");
            int exponent = Convert.ToInt32(Console.ReadLine());

            int result = obj.CalculatePower(baseNum, exponent);

            Console.WriteLine("Result: " + result);
        }
    }
}
