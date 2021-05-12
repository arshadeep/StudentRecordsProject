using StudentRecord.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecord.ViewModels
{
    public class StudentEditViewModel
    {
        
        public int RollNo { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Age")]
        [Range(3, 18)]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please enter Gender")]
        public Gender Gender { get; set; }
    }
}
