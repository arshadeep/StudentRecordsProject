using StudentRecord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecord.ViewModels
{
    public class StudentEditViewModel
    {
        
        public int RollNo { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Gender Gender { get; set; }
    }
}
