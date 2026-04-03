using System;
using System.Collections.Generic;
using System.Linq;

class StudentAnalyzer
{
    public static void AnalyzeScores()
    {
        int[] marks = { 78, 85, 90, 67, 88 };
        int threshold = 80;

        int total = marks.Sum();

        double average = marks.Average();

        int highest = marks.Max();

        var aboveThreshold = marks.Where(m => m > threshold).ToList();

        Dictionary<string, int> subjectMarks = new Dictionary<string, int>()
        {
            { "Math", 90 },
            { "Science", 88 },
            { "English", 85 }
        };

     
        Console.WriteLine("Total Marks: " + total);
        Console.WriteLine("Average Marks: " + average);
        Console.WriteLine("Students above " + threshold + ": " + aboveThreshold.Count);
        Console.WriteLine("Highest Score: " + highest);

        Console.WriteLine("\nSubject-wise Highest Marks:");
        foreach (var subject in subjectMarks)
        {
            Console.WriteLine(subject.Key + ": " + subject.Value);
        }
    }
}