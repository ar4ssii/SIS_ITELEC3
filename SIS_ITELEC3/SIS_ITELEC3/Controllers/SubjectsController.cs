using SIS_ITELEC3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIS_ITELEC3.Controllers
{
    public class SubjectsController : Controller
    {
        private ApplicationDbContext _context;

        public SubjectsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Subjects
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var subjects = new Subjects();
            return View("SubjectForm", subjects);
        }

        public ActionResult Edit(int id)
        {
            var subjects = _context.Subjects.SingleOrDefault(s => s.Id == id);
            if (subjects == null)
                return HttpNotFound();
            return View("SubjectForm", subjects);
        }

        [ValidateAntiForgeryToken]
        public ActionResult Save(Subjects subject)
        {
            if (!ModelState.IsValid)
            {
                var subjects = _context.Subjects.ToList();
                return View("SubjectForm", subjects);   
            }

            if (subject.Id == 0)
            {
                _context.Subjects.Add(subject);
            }
            else
            {
                var subjectInDB = _context.Subjects.Single(s => s.Id == subject.Id);
                subjectInDB.Name = subject.Name;
                subjectInDB.Year = subject.Year;
                subjectInDB.Semester = subject.Semester;
            }

            _context.SaveChanges();
            return RedirectToAction("Index","Subjects");
        }
    }
}