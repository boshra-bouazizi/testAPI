using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Models;
using SchoolManagement.DOMAIN;
using SchoolManagement.Services.Repositories;

namespace SchoolManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesRepository _coursesRepository;
        public CoursesController(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddCourses([FromBody] CoursesModel courses)
        {
            var coursesToAdd = new Courses()
            {
                Name = courses.Name,
                ClassId = courses.ClassId///
            };

            var addedCourses = await _coursesRepository.Add(coursesToAdd);

            if (addedCourses == null)
            {
                return BadRequest("Une erreur a surevenue");
            }
            else
            {
                return Ok(addedCourses);
            }
        }

        [HttpGet("GetCourses/{id:int}")]
        public async Task<IActionResult> GetCourses(int id)
        {
            var coursesToReturn = await _coursesRepository.GetCoursesById(id);
            return Ok(coursesToReturn);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Courses> coursesList = await _coursesRepository.GetAll();
            return Ok(coursesList);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCourses([FromBody] Courses courses)
        {
            var coursesToUpdate = await _coursesRepository.UpdateCourses(courses);

            return Ok(coursesToUpdate);
        }

        [HttpDelete]
        public async Task DeleteCourses([FromBody] Courses courses)
        {
            await _coursesRepository.DeleteCourses(courses.Id);
        }
    }

}
