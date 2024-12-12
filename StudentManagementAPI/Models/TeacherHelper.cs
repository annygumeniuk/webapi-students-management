using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementAPI.Models
{
    public class TeacherHelper : Person
    {
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }
        
        [NotMapped]
        public Student Student => Course.Student;
    }
}
