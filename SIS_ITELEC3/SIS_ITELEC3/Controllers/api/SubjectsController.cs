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
    public class SubjectsController : ApiController
    {
        private ApplicationDbContext _context;

        public SubjectsController()
        {
            _context = new ApplicationDbContext();

        }

        [HttpGet]
        public IHttpActionResult GetSubjects()
        {
            var subjectDto = _context.Subjects.ToList().Select(Mapper.Map<Subjects, SubjectsDto>);
            return Ok(subjectDto);
        }
        [HttpDelete]
        public void DeleteSubject(int id)
        {
            var subjectInDB = _context.Subjects.SingleOrDefault(s => s.Id == id);
            if (subjectInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Subjects.Remove(subjectInDB);
            _context.SaveChanges();
        }
    }
}
