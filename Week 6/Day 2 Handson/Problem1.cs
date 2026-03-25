using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_Handson
{


    class Student
    {
        public int StudentId { get; set; }
        public string Studentname { get; set; }

        public int marks { get; set; }

    }

    class StudentData : Student
    {
    
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);

        }
        public List<Student> GetStudents() { return students; }

        

    
    }

    class ReportGenerator 
    {
        public void GenerateReport(List<Student> students)
        {
            foreach (var s in students)
            {
                Console.WriteLine($"{s.Studentname} - {s.marks}");
            }
        }
    }
   

class Program
    {
        static void Main(string[] args)
        {
            
            StudentData repo = new StudentData();

            Student s1 = new Student { StudentId = 1, Studentname = "Chetan", marks = 85 };
            Student s2 = new Student { StudentId = 2, Studentname = "Rahul", marks = 90 };

            repo.AddStudent(s1);
            repo.AddStudent(s2);

            var students = repo.GetStudents();

            ReportGenerator report = new ReportGenerator();

            report.GenerateReport(students);
        }
    }
}
