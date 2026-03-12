using System;

namespace Day_4_Handson
{
    internal class Student
    {
        public int CalculateAverage(int m1, int m2, int m3)
        {
            int totalsub = m1 + m2 + m3;
            return totalsub / 3;
        }

        public static void Main(string[] args)
        {
            Student student = new Student();

            Console.Write("Enter Marks of 3 subjects: ");
            int m1 = Convert.ToInt32(Console.ReadLine());
            int m2 = Convert.ToInt32(Console.ReadLine());
            int m3 = Convert.ToInt32(Console.ReadLine());

            int result = student.CalculateAverage(m1, m2, m3);

            Console.WriteLine("Result: " + result);

            if (result >= 90)
            {
                Console.WriteLine("Grade: A");
            }
            else if (result >= 70 && result <= 89)
            {
                Console.WriteLine("Grade: B");
            }
            else if (result >= 50 && result <= 69)
            {
                Console.WriteLine("Grade: C");
            }
            else
            {
                Console.WriteLine("Grade: Fail");
            }
        }
    }
}