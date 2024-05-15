using AutoMapper;
using SIS_ITELEC3.Dtos;
using SIS_ITELEC3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace SIS_ITELEC3.Controllers.api
{
    public class InstructorController : ApiController
    {
        private ApplicationDbContext _context;

        public InstructorController()
        {
            _context = new ApplicationDbContext();

        }

        [HttpGet]
        public IHttpActionResult GetInstructors()
        {
            var instructorsDto = _context.Instructors
                .Include(i => i.Subject)
                .ToList()
                .Select(Mapper.Map<Instructors, InstructorsDto>);
            return Ok(instructorsDto);
        }

        [HttpDelete]
        public void DeleteInstructor(int id)
        {
            var instructorInDB = _context.Instructors.SingleOrDefault(i => i.Id == id);
            if(instructorInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Instructors.Remove(instructorInDB);
            _context.SaveChanges();
        }
    }
}
