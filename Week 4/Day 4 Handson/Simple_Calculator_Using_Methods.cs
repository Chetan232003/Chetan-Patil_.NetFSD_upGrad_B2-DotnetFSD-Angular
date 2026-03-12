using System;


namespace Day_4_Handson
{
    internal class Simple_Calculator_Using_Methods
    {

        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Sub(int a, int b) 
        {
            return a - b;
        }

        public static void Main(string[] args) 
        {
        Simple_Calculator_Using_Methods calculat = new Simple_Calculator_Using_Methods();

            Console.Write("Enter the Number 1 : ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Number 2 : ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            var result = calculat.Add(num1, num2);
            Console.WriteLine("Addition :" + result);
            var result1 = calculat.Sub(num1, num2);
            Console.WriteLine("Substraction : "+ result1);

        }
    }
}
