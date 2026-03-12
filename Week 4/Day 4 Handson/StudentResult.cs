using System;


namespace Day_4_Handson
{
    internal class StudentResult
    {
        public void CalculateResult(int m1,int m2,int m3 ,out int total , out double average) 
        {
             total = m1 + m2 + m3;
            average = total / 3;
            
        }

        public static void Main(string[] args) 
        {
            StudentResult result = new StudentResult();

            Console.WriteLine("Enter marks of 3 subjects:");

            int m1 = Convert.ToInt32(Console.ReadLine());
            int m2 = Convert.ToInt32(Console.ReadLine());
            int m3 = Convert.ToInt32(Console.ReadLine());

            int total;
            double average;

            
            result.CalculateResult(m1, m2, m3, out total, out average);

            Console.WriteLine("Total Marks: " + total);
            Console.WriteLine("Average Marks: " + average);

            if (average >= 40)
                Console.WriteLine("Result: Pass");
            else
                Console.WriteLine("Result: Fail");


        }
    }
}
