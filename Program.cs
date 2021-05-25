using System;
using System.Collections.Generic;
using System.Linq;
using App.Models;

namespace App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var db = new SchoolDbContext();
            //SHOW A LIST OF STUDENTS 
            List<Student> result = db.Student.ToList();
            foreach (var student in result)
                Console.WriteLine($"This is the student {student.FirstName} {student.LastName}");
            //Setting up the students to have grades as done in your example
            IQueryable<Grade> grade1 = db.Grade.Where(x => x.StudentId == 1);
            db.Student.Where(x => x.FirstName == "Kevin").FirstOrDefault().Grades = grade1.ToList();
            var student1 = db.Student.First(x => x.FirstName == "Kevin");

            IQueryable<Grade> grade2 = db.Grade.Where(x => x.StudentId == 2);
            db.Student.Where(x => x.FirstName == "Dummy").FirstOrDefault().Grades = grade2.ToList();
            var student2 = db.Student.First(x =>x.FirstName == "Dummy");

            IQueryable<Grade> grade3 = db.Grade.Where(x => x.StudentId == 3);
            db.Student.Where(x => x.FirstName == "Water").FirstOrDefault().Grades = grade3.ToList();
            var student3 = db.Student.First(x => x.FirstName == "Water");

            IQueryable<Grade> grade4 = db.Grade.Where(x => x.StudentId == 4);
            db.Student.Where(x => x.FirstName == "Sophie").FirstOrDefault().Grades = grade4.ToList();
            var student4 = db.Student.First(x => x.FirstName == "Sophie");

            //Given a student's name, show their grades
            var student1Grade = db.Student.Where(student => student.FirstName == "Kevin").First();
            Console.WriteLine($"Student1: {student1.FirstName} {student1.LastName} Grades");
            student1Grade.Grades.ForEach(x=> Console.WriteLine($"Grades: {x.GradeScore}"));

            var student2Grade = db.Student.Where(student => student.FirstName == "Dummy").First();
            Console.WriteLine($"Student2: {student2Grade.FirstName} {student2Grade.LastName} Grades");
            student2Grade.Grades.ForEach(x => Console.WriteLine($"Grades: {x.GradeScore}"));

            var student3Grade = db.Student.Where(student => student.FirstName == "Water").First();
            Console.WriteLine($"Student3: {student3Grade.FirstName} {student3Grade.LastName} Grades");
            student3Grade.Grades.ForEach(x => Console.WriteLine($"Grades: {x.GradeScore}"));
            
            var student4Grade = db.Student.Where(student => student.FirstName == "Sophie").First();
            Console.WriteLine($"Student4: {student4Grade.FirstName} {student4Grade.LastName} Grades");
            student4Grade.Grades.ForEach(x => Console.WriteLine($"Grades: {x.GradeScore}"));

            //Given a student's name find their average grade among all their courses
            //since you cant use LINQ in list<grades> i just added the grades in the list<float> and found the avg 
            List<float> avg1 = new();
            List<float> avg2 = new();
            List<float> avg3 = new();
            List<float> avg4 = new();
            student1.Grades.ForEach(x => avg1.Add(x.GradeScore));
            student2.Grades.ForEach(x => avg2.Add(x.GradeScore));
            student3.Grades.ForEach(x => avg3.Add(x.GradeScore));
            student4.Grades.ForEach(x => avg4.Add(x.GradeScore));
            
            Console.WriteLine($"Student1: {student1.FirstName} {student1.LastName} Average Grades");
            Console.Out.WriteLine("\n");
            Console.WriteLine(student1.Grades.Count == 0
                ? "Student1: No Grades"
                : $"Student1: {student1.FirstName} {student1.LastName} Average Grades = {avg1.Average()}");
            Console.WriteLine(student2.Grades.Count == 0
                ? "Student2: No Grades"
                : $"Student2: {student2.FirstName} {student2.LastName} Average Grades = {avg2.Average()}");
            Console.WriteLine(student3.Grades.Count == 0
                ? "Student3: No Grades"
                : $"Student3: {student3.FirstName} {student3.LastName} Average Grades = {avg3.Average()}");
            Console.WriteLine(student4.Grades.Count == 0
                ? "Student4: No Grades"
                : $"Student4: {student4.FirstName} {student4.LastName} Average Grades = {avg4.Average()}");
            //Find the student with the highest average grade
            float highestAvg = 0;
            List<Student> listofStudents = new();

            db.Student.Where(x => true).ToList().ForEach(student =>
            {
                float hold = 0;
                var numberOfGrades = 0;

                foreach (var grade in student.Grades)
                {
                    hold += grade.GradeScore;
                    numberOfGrades++;
                }

                var avg = hold / numberOfGrades;
                //find avg and compare to the maxValue 
                if (highestAvg < avg)
                {
                    highestAvg = hold / numberOfGrades;
                    if (listofStudents.Count >= 1) listofStudents.RemoveAt(listofStudents.Count - 1);

                    listofStudents.Add(student);
                }
                else if (highestAvg == avg)
                {
                    listofStudents.Add(student);
                }
            });

            listofStudents.ForEach(x =>
            {
                Console.WriteLine($"Has the highest average : {x.FirstName} {x.LastName}");
            });
            //Find the student that took the most number of courses
            var highestGradesCount = 0;

            db.Student.Where(x => true).ToList()
                .ForEach(x => highestGradesCount = Math.Max(highestGradesCount, x.Grades.Count));
            db.Student.Where(x => true).ToList().ForEach(student =>
            {
                if (student.Grades.Count == highestGradesCount)
                    Console.WriteLine(
                        $"Student {student.FirstName} {student.LastName}  took the most number of courses");
            });
            //Find a student that didn't take any courses
            var studentWithNoGrades = db.Student.Where(grades => grades.Grades.Count == 0).FirstOrDefault();
            if (studentWithNoGrades != null)
                Console.WriteLine(
                    $"Student with no grades {studentWithNoGrades.FirstName} {studentWithNoGrades.LastName}");
            else
                Console.Out.WriteLine("Every Student Has a Grade");
            //Count the number of Freshmen
            List<Student> freshman = db.Student.Where(x => x.Classification == CollegeClassification.Freshman).ToList();
            Console.WriteLine($"There are {freshman.Count} Freshman");
            //Find the average grade for all Sophomores
            List<List<Grade>> sophmoreAvgGtade = db.Student
                .Where(x => x.Classification == CollegeClassification.Sophomore)
                .Select(x => x.Grades).ToList();
            float sophomoreAdded = 0;
            var sophomoreGradeCount = 0;
            foreach (List<Grade> item in sophmoreAvgGtade)
            foreach (var grade in item)
            {
                sophomoreGradeCount++;
                sophomoreAdded += grade.GradeScore;
            }

            var sophomoreAvgGrade = sophomoreAdded / sophomoreGradeCount;

            Console.WriteLine(sophomoreAvgGrade);
        }
    }
}