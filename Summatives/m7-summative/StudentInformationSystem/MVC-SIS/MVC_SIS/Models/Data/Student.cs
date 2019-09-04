using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "First name required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name required")]
        public string LastName { get; set; }

        [Range(0, 4, ErrorMessage = "Please enter a GPA between 0 and 4")]
        public decimal GPA { get; set; }

        [Required(ErrorMessage = "Address required")]
        public Address Address { get; set; }

        [Required(ErrorMessage = "Please enter a major")]
        public Major Major { get; set; }

        public List<Course> Courses { get; set; }
    }
}