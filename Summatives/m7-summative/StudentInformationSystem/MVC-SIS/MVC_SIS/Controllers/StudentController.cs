using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new ADDVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(ADDVM ADDVM)
        {

            if (ModelState.IsValid)
            {
                Student student = new Student();
                student.StudentId = ADDVM.StudentId;
                student.FirstName = ADDVM.FirstName;
                student.LastName = ADDVM.LastName;
                student.GPA = ADDVM.GPA;
                student.Courses = ADDVM.Courses;
                student.Major = MajorRepository.Get(ADDVM.MajorId);

                student.Courses = new List<Course>();

                foreach (var id in ADDVM.SelectedCourseIds)
                    student.Courses.Add(CourseRepository.Get(id)); 

     
                if (student.Courses.Count == 0)
                {
                    ModelState.AddModelError("Courses", "You MUST select a course.");
                    return View(ADDVM);
                }
                StudentRepository.Add(student);

                return RedirectToAction("List");
            }
            else
            {
                var viewModel = ADDVM;//error here i think
                viewModel.SetCourseItems(CourseRepository.GetAll());
                viewModel.SetMajorItems(MajorRepository.GetAll());
                return View(viewModel);
            }

        }

        [HttpGet]
        public ActionResult Edit(int studentId)
        {
            {
                var viewModel = new StudentVM();

                viewModel.Student = StudentRepository.Get(studentId);
                viewModel.SetCourseItems(CourseRepository.GetAll());
                viewModel.SetMajorItems(MajorRepository.GetAll());
                viewModel.SetStateItems(StateRepository.GetAll());
                return View(viewModel);
            }

        }

        [HttpPost]
        public ActionResult Edit(StudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);
            
                StudentRepository.Edit(studentVM.Student);
                return RedirectToAction("List");
            }
            else
            {
                var viewModel = studentVM;
                viewModel.SetCourseItems(CourseRepository.GetAll());
                viewModel.SetMajorItems(MajorRepository.GetAll());
                viewModel.SetStateItems(StateRepository.GetAll());
                return View(viewModel);
            }

        }

        [HttpPost]
        public ActionResult EditStudentVM(StudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                StudentRepository.SaveAddress(studentVM.Student.StudentId, studentVM.Student.Address);
                return RedirectToAction("List");
            }
            else
            {
                studentVM.Student = StudentRepository.Get(studentVM.Student.StudentId);
                studentVM.SetCourseItems(CourseRepository.GetAll());
                studentVM.SetMajorItems(MajorRepository.GetAll());
                return View("Edit", studentVM);

            }
        }

        [HttpGet]
        public ActionResult Delete(int studentId)
        {
            var viewModel = new StudentVM();
            viewModel.Student = StudentRepository.Get(studentId);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(StudentVM studentVM)
        {
            StudentRepository.Delete(studentVM.Student.StudentId);
            return RedirectToAction("List");
        }
    }
}