using Microsoft.AspNetCore.Mvc;
using StudentRecord.Models;
using StudentRecord.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecord.Controllers
{
    public class HomeController:Controller
    {
        private IStudentRepository _studentRepository { get; }
        public HomeController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        

        public ViewResult Index()
        {
            var model = _studentRepository.GetAllStudents();
            return View(model);
        }

        //public ObjectResult Details()
        //{
        //    var model = _studentRepository.GetStudent(1);
        //    return new ObjectResult(model);
        //}
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                Student student1 = new Student
                {
                    Age = student.Age,
                    Name = student.Name,
                    Gender = student.Gender
                };
                _studentRepository.Add(student1);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int RollNo)
        {
            Student student = _studentRepository.GetStudent(RollNo);
            StudentEditViewModel studentEditViewModel=new StudentEditViewModel
            {
                RollNo = student.RollNo,
                Name = student.Name,
                Gender=student.Gender,
                Age=student.Age
            };
            return View(studentEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(StudentEditViewModel studentEditViewModel)
        {
            if(ModelState.IsValid)
            {
                Student student = _studentRepository.GetStudent(studentEditViewModel.RollNo);
                student.Name = studentEditViewModel.Name;
                student.Age = studentEditViewModel.Age;
                student.Gender = studentEditViewModel.Gender;
                _studentRepository.Update(student);
                return RedirectToAction("index");
            }
            return View();
            
        }
        [HttpGet]
        public IActionResult Delete(int RollNo)
        {
            
           Student student= _studentRepository.Delete(RollNo);
            
            return RedirectToAction("index",student);
        }
        [HttpGet]
        public ViewResult Search()
        {
            
            return View();
            
        }
        [HttpPost]
        public ViewResult Search(Search s)
        {
            var model = _studentRepository.GetAllStudents();
            List<Student> t = new List<Student>();
            foreach(var v in model)
            {
                if(v.Name.ToLower()==s.SearchTerm.ToLower())
                {
                    t.Add(v);
                }
            }
            if (t.Count!=0)
            {
                List<Student> s2 = new List<Student>();
                foreach (var m in t)
                {
                    s2.Add(_studentRepository.GetStudent(m.RollNo));
                }
                return View("Data", s2);
            }
            else
            {
                return View("Error");
            }


            //Student student = _studentRepository.GetStudent(s.SearchTerm);

            //    if (student != null)
            //    {
            //        return View("Data", student);
            //    }

               
            
            //return View("Error");
        }
    }
}
