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

        //[HttpGet("GetClass/{id:int}")]
        //public async Task<IActionResult> GetClass(int id)
        //{
        //    var classToReturn = await _classRepository.GetClassById(id);
        //    return Ok(classToReturn);
        //}

        //[HttpGet()]
        //public async Task<IActionResult> GetAll()
        //{
        //    IEnumerable<Class> classList = await _classRepository.GetAll();
        //    return Ok(classList);
        //}

        //[HttpPut]
        //public async Task<IActionResult> UpdateClass([FromBody] Class _class)
        //{
        //    var classToUpdate = await _classRepository.UpdateClass(_class);

        //    return Ok(classToUpdate);
        //}

        //[HttpDelete]
        //public async Task DeleteClass([FromBody] Class _class)
        //{
        //    await _classRepository.DeleteClass(_class.Id);
        //}
    }

}
