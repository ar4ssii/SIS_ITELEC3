using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIS_ITELEC3.Models;

namespace SIS_ITELEC3.viewModels
{
    public class SubjectFormViewModels
    {
        public IEnumerable<Instructors> Instructor { get; set; }
        public Subjects Subject { get; set; }
    }
}