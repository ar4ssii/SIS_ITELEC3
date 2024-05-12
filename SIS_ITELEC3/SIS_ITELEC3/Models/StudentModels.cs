using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIS_ITELEC3.Models
{
    public class StudentModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime Year { get; set; }
        public string Section { get; set; }
        public int Age { get; set; }
        public DateTime Birthdate { get; set; }
    }
}