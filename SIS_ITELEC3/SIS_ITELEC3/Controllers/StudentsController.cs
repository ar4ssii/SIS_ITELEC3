using SIS_ITELEC3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIS_ITELEC3.Controllers
{
    public class StudentsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult New()
        {


            return View("StudentForm");
        }

        //POST: Students/Save
        [HttpPost]
        public ActionResult Save(StudentModels model)
        {
            if (ModelState.IsValid)
            {
                // Save the student data to the database or perform any other necessary actions
                // For demonstration purposes, let's assume we redirect to the home page after saving
                return RedirectToAction("Index", "Home");
            }

            // If the model state is not valid, redisplay the form with validation errors
            return View(model);
        }
    }
}