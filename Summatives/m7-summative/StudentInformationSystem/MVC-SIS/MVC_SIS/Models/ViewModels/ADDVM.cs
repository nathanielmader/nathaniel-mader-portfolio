using Exercises.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Models.ViewModels
{
    public class ADDVM
    {
        public List<SelectListItem> CourseItems { get; set; }
        public List<SelectListItem> MajorItems { get; set; }
        public List<int> SelectedCourseIds { get; set; }

        public ADDVM()
        {
            CourseItems = new List<SelectListItem>();
            MajorItems = new List<SelectListItem>();
            SelectedCourseIds = new List<int>();
        }

        public int StudentId { get; set; }

        [Required(ErrorMessage = "First name required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name required")]
        public string LastName { get; set; }

        [Range(0, 4, ErrorMessage = "Please enter a GPA between 0 and 4")]
        public decimal GPA { get; set; }

        [Required(ErrorMessage = "Please enter a major")]
        public int MajorId { get; set; }

        public List<Course> Courses { get; set; }



        public void SetCourseItems(IEnumerable<Course> courses)
        {
            foreach (var course in courses)
            {
                CourseItems.Add(new SelectListItem()
                {
                    Value = course.CourseId.ToString(),
                    Text = course.CourseName
                });
            }
        }

        public void SetMajorItems(IEnumerable<Major> majors)
        {
            foreach (var major in majors)
            {
                MajorItems.Add(new SelectListItem()
                {
                    Value = major.MajorId.ToString(),
                    Text = major.MajorName
                });
            }
        }
    }
}