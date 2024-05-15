using SIS_ITELEC3.Models;
using SIS_ITELEC3.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIS_ITELEC3.Controllers
{
    public class InstructorController : Controller
    {
        private ApplicationDbContext _context;

        public InstructorController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Instructor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var subjects = _context.Subjects.ToList();
            var viewModel = new InstructorFormViewModel
            {
                Instructor = new Instructors(),
                Subjects = subjects,
            };
            return View("InstructorForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var instructors = _context.Instructors.SingleOrDefault(i => i.Id == id);

            if (instructors == null)
                return HttpNotFound();

            var viewModel = new InstructorFormViewModel
            {
                Instructor = instructors,
                Subjects = _context.Subjects.ToList()
            };

            return View("InstructorForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Save(Instructors instructor)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new InstructorFormViewModel
                {
                    Instructor = instructor,
                    Subjects = _context.Subjects.ToList()
                };
                return View("InstructorForm", viewModel);
            }

            if (instructor.Id == 0)
            {
                _context.Instructors.Add(instructor);
            }
            else
            {
                var instructorInDB = _context.Instructors.Single(i => i.Id == instructor.Id);
                instructorInDB.Name = instructor.Name;
                instructorInDB.isOverload = instructor.isOverload;
                instructorInDB.SubjectId = instructor.SubjectId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Instructor");
        }
    }
}