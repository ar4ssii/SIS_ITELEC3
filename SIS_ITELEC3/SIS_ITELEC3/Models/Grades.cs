using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIS_ITELEC3.Models
{
    public class Grades
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Range(1.0,5.0)]
        public double Rating { get; set; }
        public Students Student { get; set; }
        public int StudentId { get; set; }

    }
}