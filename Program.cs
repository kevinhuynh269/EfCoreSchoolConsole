using System;
using System.Collections.Generic;
using System.Linq;
using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var db = new SchoolDbContext();
            List<Student> result = db.Student.ToList();
            foreach (var student in result)
                Console.WriteLine($"This is the student {student.FirstName} {student.LastName}");

            IQueryable<Grade> grade1 = db.Grade.Where(x => x.StudentId == 1);
            db.Student.Where(x => x.Id == 1).FirstOrDefault().CourseGrade = grade1.ToList();
            var student1 = db.Student.Where(x => x.Id == 1).First();

            IQueryable<Grade> grade2 = db.Grade.Where(x => x.StudentId == 2);
            db.Student.Where(x => x.Id == 2).FirstOrDefault().CourseGrade = grade2.ToList();
            var student2 = db.Student.Where(x => x.Id == 2).First();

            IQueryable<Grade> grade3 = db.Grade.Where(x => x.StudentId == 3);
            db.Student.Where(x => x.Id == 3).FirstOrDefault().CourseGrade = grade3.ToList();
            var student3 = db.Student.Where(x => x.Id == 3).First();


            Console.WriteLine($"Student1: {student1.FirstName} {student1.LastName} Grades");
            student1.CourseGrade.ForEach(x => Console.WriteLine($"Grades: {x.Grades}"));

            Console.WriteLine($"Student2: {student2.FirstName} {student2.LastName} Grades");
            student2.CourseGrade.ForEach(x => Console.WriteLine($"Grades: {x.Grades}"));

            Console.WriteLine($"Student3: {student3.FirstName} {student3.LastName} Grades");
            student3.CourseGrade.ForEach(x => Console.WriteLine($"Grades: {x.Grades}"));

            List<float> avg1 = new List<float>();
            List<float> avg2 = new List<float>();
            List<float> avg3 = new List<float>();
            student1.CourseGrade.ForEach(x => avg1.Add(x.Grades));
            student2.CourseGrade.ForEach(x => avg2.Add(x.Grades));
            student3.CourseGrade.ForEach(x => avg3.Add(x.Grades));
            Console.WriteLine($"Student1: {student1.FirstName} {student1.LastName} Average Grades");
            Console.Out.WriteLine("\n");
            Console.WriteLine(student1.CourseGrade.Count == 0
                ? "Student1: No Grades"
                : $"Student1: {student1.FirstName} {student1.LastName} Average Grades = {avg1.Average()}");
            Console.WriteLine(student2.CourseGrade.Count == 0
                ? "Student2: No Grades"
                : $"Student2: {student2.FirstName} {student2.LastName} Average Grades = {avg2.Average()}");
            Console.WriteLine(student3.CourseGrade.Count == 0
                ? "Student3: No Grades"
                : $"Student3: {student3.FirstName} {student3.LastName} Average Grades = {avg3.Average()}");

            double avgval1 = 0;
            if (student1.CourseGrade.Count != 0) avgval1 = avg1.Average();

            double avgval2 = 0;
            if (student2.CourseGrade.Count != 0) avgval2 = avg2.Average();

            double avgval3 = 0;
            if (student3.CourseGrade.Count != 0) avgval3 = avg3.Average();

            var maxValue = Math.Max(avgval1, Math.Max(avgval2, avgval3));

            if (avgval1 == maxValue)
                Console.WriteLine($"Has the highest average : {student1.FirstName} {student1.LastName}");
            else if (avgval2 == maxValue)
                Console.WriteLine($"Has the highest average : {student2.FirstName} {student2.LastName}");
            else
                Console.WriteLine($" Has the highest average : {student3.FirstName} {student3.LastName}");
            
            int highestGradesCount = 0;
            
            db.Student.Where(x => true).ToList().ForEach(x=>highestGradesCount = Math.Max(highestGradesCount,x.CourseGrade.Count));
            db.Student.Where(x => true).ToList().ForEach((student) =>
            {
                if (student.CourseGrade.Count == highestGradesCount)
                    Console.WriteLine($"Student {student.FirstName} {student.LastName}  took the most number of courses");
            });


        }
    }
}