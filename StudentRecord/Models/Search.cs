using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecord.Models
{
    public class Search
    {
        //[Display(Name = "Search By roll no")]
        //public int SearchTerm { get; set; }
        [Display(Name = "Search By Full Name")]
        public string SearchTerm { get; set; }
    }
}
