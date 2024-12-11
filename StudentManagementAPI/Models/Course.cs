using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementAPI.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int    Id          { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "The minimun leght is 6")]
        public string Name        { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        [StringLength(100, MinimumLength = 20, ErrorMessage = "The description is too short")]
        public string Description { get; set; }

        // Foreign key 
        public int StudentId      { get; set; }

        // Navigation property to Students entity
        [ForeignKey("StudentId")]
        public Student Student    { get; set; }

        // Navigation property: one-to-one
        public Teacher Teacher    { get; set; }
    }
}
