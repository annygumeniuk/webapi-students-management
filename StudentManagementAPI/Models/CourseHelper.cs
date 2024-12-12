using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementAPI.Models
{
    public class CourseHelper
    {
        [Required(ErrorMessage = "This field is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "The minimun leght is 6")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(100, MinimumLength = 20, ErrorMessage = "The description is too short")]
        public string Description { get; set; }

        // Foreign key 
        public int StudentId { get; set; }

        // Navigation property to Students entity
        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        // Navigation property: one-to-one
        public Teacher Teacher { get; set; }
    }
}
