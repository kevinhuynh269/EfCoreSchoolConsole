using System.Collections.Generic;

namespace App.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public CollegeClassification Classification { get; set; }

        public List<Grade> CourseGrade { get; set; }
    }
}