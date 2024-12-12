using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementAPI.Models
{
    public class Teacher : Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
