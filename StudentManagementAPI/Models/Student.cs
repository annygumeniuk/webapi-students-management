﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementAPI.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "This field is required")]
        public string Email { get; set; }

        [StringLength(100, MinimumLength = 6, ErrorMessage = "The minimun leght is 6")]
        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }

        // Navigation property: one-to-many 
        public ICollection<StudentCourse>? StudentCourses { get; set; }
    }
}
