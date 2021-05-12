using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecord.Models
{
    public class StudentRepository : IStudentRepository
    {
        private List<Student> students;

        public StudentRepository()
        {
            students = new List<Student>()
            {
                new Student(){RollNo=1,Name="Arsh",Gender=Gender.Male,Age=15},
                new Student(){RollNo=2,Name="Raman",Gender=Gender.Male,Age=15},
                new Student(){RollNo=3,Name="Sonya",Gender=Gender.Female,Age=15},
                new Student(){RollNo=4,Name="Rohail",Gender=Gender.Other,Age=15},
                new Student(){RollNo=5,Name="Ramya",Gender=Gender.Female,Age=12},
                new Student(){RollNo=6,Name="Soni",Gender=Gender.Female,Age=13},
            };
        }

        public Student GetStudent(int RollNo)
        {
            return students.FirstOrDefault(s => s.RollNo==RollNo);
        }
        public Student Add(Student student)
        {
           
                student.RollNo = students.Max(e => e.RollNo) + 1;
                students.Add(student);
                return student;
            
        }

        

        public IEnumerable<Student> GetAllStudents()
        {
            return students;
        }

        public Student Update(Student studentChanges)
        {
            Student student = students.FirstOrDefault(x => x.RollNo == studentChanges.RollNo);
            if (student != null)
            {
                student.Name = studentChanges.Name;
                student.Age = studentChanges.Age;
                student.Gender = studentChanges.Gender;
            }
            return student;
        }

        public Student Delete(int RollNo)
        {
            Student student = students.FirstOrDefault(x => x.RollNo == RollNo);
            if (student != null)
            {
                students.Remove(student);
            }
            return student;
        }
    }
}
