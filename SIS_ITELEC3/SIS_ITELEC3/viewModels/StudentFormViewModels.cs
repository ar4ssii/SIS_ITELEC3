using SIS_ITELEC3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIS_ITELEC3.viewModels
{
    public class StudentFormViewModels
    {
        public List<Courses> Course { get; set; }
        public List<Grades> Grade { get; set; }
        public StudentModels Student { get; set; }
    }
}