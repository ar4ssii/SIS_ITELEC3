using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using SIS_ITELEC3.Dtos;
using SIS_ITELEC3.Models;

namespace SIS_ITELEC3.Controllers.api
{
    public class StudentsController : ApiController
    {
        private ApplicationDbContext _context;

        public StudentsController()
        {
            _context = new ApplicationDbContext();

        }

        [HttpGet]
        public IHttpActionResult GetStudents()
        {
            var studentsDto = _context.Students.ToList().Select(Mapper.Map<Students, StudentsDto>);
            return Ok(studentsDto);
        }

        [HttpDelete]
        public void DeleteStudent(int id)
        {
            var studentInDB = _context.Students.SingleOrDefault(s => s.Id == id);
            if (studentInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Students.Remove(studentInDB);
            _context.SaveChanges();
        }
    }
}
