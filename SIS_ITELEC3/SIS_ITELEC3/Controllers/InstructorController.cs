using SIS_ITELEC3.Models;
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
            var instructors = _context.Instructors.ToList();
            return View(instructors);
        }

        public ActionResult New()
        {
            var instructors = new Instructors();
            return View("InstructorForm", instructors);
        }

        public ActionResult Edit(int id)
        {
            var instructors = _context.Instructors.SingleOrDefault(i => i.Id == id);

            if(instructors == null)
                return HttpNotFound();

            return View("InstructorForm", instructors);
        }

        public ActionResult Save(Instructors instructor)
        {
            if (!ModelState.IsValid)
            {
                var instructors = _context.Instructors.ToList();
                return View("InstructorForm", instructors);
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
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Instructor");
        }
    }
}