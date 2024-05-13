using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIS_ITELEC3.Models
{
    public class StudentModels
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Address { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string Section { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }


        public Courses Course { get; set; }
        public int CourseId { get; set; }
        public Grades Grade { get; set; }
        public int GradeId { get; set; }
    }
}