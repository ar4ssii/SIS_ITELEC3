using AutoMapper;
using SIS_ITELEC3.Dtos;
using SIS_ITELEC3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
            var instructorDto = _context.Instructors.ToList().Select(Mapper.Map<Instructors, InstructorsDto>);
            return Ok(instructorDto);
        }


    }
}
