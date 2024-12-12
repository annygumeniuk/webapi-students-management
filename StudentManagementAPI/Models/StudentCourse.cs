namespace StudentManagementAPI.Models
{    
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public int CourseId  { get; set; }

        // navigation properties
        public Student Student { get; set; }
        public Course  Course  { get; set; }
    }
}
