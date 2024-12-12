﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementAPI.Models
{
    public class Person
    {       
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "This field is required")]
        public string Email { get; set; }

        [StringLength(100, MinimumLength = 6, ErrorMessage = "The minimun leght is 6")]
        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }
    }    
}