using System;

namespace Student_Grade_Evaluator
{
    internal class Student_Grade_Evaluator
    {
        public static void Main()
        {
            Console.WriteLine("Student Grade Evaluator");

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Marks: ");
            int marks = Convert.ToInt32(Console.ReadLine());

            if (marks >= 90)
            {
                Console.WriteLine("Name: " + name);
                Console.WriteLine("Grade: A");
            }
            else if (marks >= 60 && marks <= 89)
            {
                Console.WriteLine("Name: " + name);
                Console.WriteLine("Grade: B");
            }
            else if (marks >= 40 && marks <= 59)
            {
                Console.WriteLine("Name: " + name);
                Console.WriteLine("Grade: C");
            }
            else
            {
                Console.WriteLine("Name: " + name);
                Console.WriteLine("Grade: Fail");
            }
        }
    }
}