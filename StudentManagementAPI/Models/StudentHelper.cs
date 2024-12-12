using System.ComponentModel.DataAnnotations;

namespace StudentManagementAPI.Models
{
    public class StudentHelper : Person
    {                              
        public ICollection<Course>? Courses { get; set; }
    }
}
