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
    public class ClassController : ControllerBase
    {
        private readonly IClassRepository _classRepository;
        public ClassController(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddClass([FromBody] ClassModel _class)
        {
            var classToAdd = new Class()
            {
                Name = _class.Name,
                Division = _class.Division
            };

            var addedClass = await _classRepository.Add(classToAdd);

            if (addedClass == null)
            {
                return BadRequest("Une erreur a surevenue");
            }
            else
            {
                return Ok(addedClass);
            }
        }

        [HttpGet("GetClass/{id:int}")]
        public async Task<IActionResult> GetClass(int id)
        {
            var classToReturn = await _classRepository.GetClassById(id);
            return Ok(classToReturn);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Class> classList = await _classRepository.GetAll();
            return Ok(classList);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClass([FromBody] Class _class)
        {
            var classToUpdate = await _classRepository.UpdateClass(_class);

            return Ok(classToUpdate);
        }

        [HttpDelete]
        public async Task DeleteClass([FromBody] Class _class)
        {
            await _classRepository.DeleteClass(_class.Id);
        }
    }

}