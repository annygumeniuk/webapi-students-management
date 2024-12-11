using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementAPI.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int    Id       { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Name     { get; set; }
        
        [EmailAddress]
        [Required(ErrorMessage = "This field is required")]
        public string Email    { get; set; }

        [StringLength(100, MinimumLength = 6, ErrorMessage = "The minimun leght is 6")]
        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }

        // Foreign key
        public int CourseId    { get; set; }

        // Navigation property to Course entity
        [ForeignKey("CourseId")]
        public Course Course   { get; set; }

        // To access Students entity through Course entity
        [NotMapped]
        public Student Student => Course.Student;
    }
}
