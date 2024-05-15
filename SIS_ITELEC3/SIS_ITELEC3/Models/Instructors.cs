using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIS_ITELEC3.Models
{
    public class Instructors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isOverload { get; set; }   

        public Subjects Subject { get; set; }

        public int SubjectId { get; set; }
    }
}