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
                Name = courses.Name
                //ClassId = courses.ClassId
            };

            var addedCourses = await _coursesRepository.AddCourses(coursesToAdd);

            if (addedCourses == false)
            {
                return BadRequest("Failure to add item");
            }
            else
            {
                return Ok("Addition successfully");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourses(int id)
        {
            var coursesToReturn = await _coursesRepository.GetCourses(id);
            if(coursesToReturn==null)
{
 return NotFound("Not found item.");
}
else 
            {
                return Ok(coursesToReturn);
            }

        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Courses> coursesList = await _coursesRepository.GetAll();
            return Ok(coursesList);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCourses([FromBody] Courses coursesPut)
        {

		if(coursesPut==null)
{
return NotFound("No founded item.");
}
else
{
await _coursesRepository.UpdateCourses(coursesPut);
return Ok("ok");
}
                 
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCourses(int id)
        {
Courses coursesToDelete=await _coursesRepository.GetCourses(id);
if(coursesToDelete==null)
{
return NotFound("Not founded item");
}
else
{
await _coursesRepository.DeleteCourses(coursesToDelete);
return Ok("Suppression with success");
}

            
        }
    }

}
