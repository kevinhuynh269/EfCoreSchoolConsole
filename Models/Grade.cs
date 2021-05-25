namespace App.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string CourseName { get; set; }
        public float Grades { get; set; }
    }
}