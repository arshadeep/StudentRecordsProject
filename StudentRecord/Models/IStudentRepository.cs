using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecord.Models
{
    public interface IStudentRepository
    {
        Student GetStudent(int RollNo);
        IEnumerable<Student> GetAllStudents();
        Student Add(Student student);

        Student Update(Student studentChanges);
        Student Delete(int RollNo);
    }
}
