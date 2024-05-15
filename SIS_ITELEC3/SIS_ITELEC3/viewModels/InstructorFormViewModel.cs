using SIS_ITELEC3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIS_ITELEC3.viewModels
{
    public class InstructorFormViewModel
    {
        public Instructors Instructor { get; set; }
        public IEnumerable<Subjects> Subjects { get; set; }

        public string Title
        {
            get
            {
                if (Instructor != null && Instructor.Id != 0)
                    return "Edit Instructor";

                return "New Instructor";
            }
        }
    }
}