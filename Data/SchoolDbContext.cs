using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                "Data Source=app.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Grade[] grades = new[]
            {
                new() {Id = 1, CourseName = "Calculus", Grades = 100, StudentId = 1},
                new Grade {Id = 2, CourseName = "Physics", Grades = 90, StudentId = 1},
                new Grade {Id = 3, CourseName = "Writing", Grades = 30, StudentId = 1},
                new Grade {Id = 4, CourseName = "Speech", Grades = 50, StudentId = 1},
                new Grade {Id = 5, CourseName = "Calculus", Grades = 10, StudentId = 2},
                new Grade {Id = 6, CourseName = "Physics", Grades = 20, StudentId = 2},
                new Grade {Id = 7, CourseName = "Writing", Grades = 30, StudentId = 2}
            };


            Student[] student = new[]
            {
                new()
                {
                    Id = 1, Age = 23, Classification = CollegeClassification.Freshman, FirstName = "Kevin",
                    LastName = "Huynh"
                },
                new Student
                {
                    Id = 2, Age = 23, Classification = CollegeClassification.Sophomore, FirstName = "Dummy",
                    LastName = "Name"
                },
                new Student
                {
                    Id = 3, Age = 30, Classification = CollegeClassification.Senior, FirstName = "Water",
                    LastName = "CAP"
                }
            };


            modelBuilder.Entity<Grade>().HasData(grades);
            modelBuilder.Entity<Student>().HasData(student);
            base.OnModelCreating(modelBuilder);
        }
    }
}