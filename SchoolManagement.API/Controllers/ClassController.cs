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

            var addedClass = await _classRepository.AddClass(classToAdd);

            if (addedClass == false)
            {
                return BadRequest("Failure to add item");
            }
            else
            {
                return Ok("Addition successfully");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetClass(int id)
        {
            var classToReturn = await _classRepository.GetClass(id);
            if (classToReturn == null)
            {
                return NotFound("Not found item.");
            }
            else
            {
                return Ok(classToReturn);
            }

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
            if (_class == null)
            { 
                return NotFound("No founded item."); 
            }
            else 
            {
                await _classRepository.UpdateClass(_class);
                return Ok("Updating successfully");
            }
            

            
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            Class classToDelete =await _classRepository.GetClass(id);
            if (classToDelete==null) 
            { 
                return NotFound("Not founded item"); 
            }
            else 
            {
                await _classRepository.DeleteClass(classToDelete);
                return Ok("Suppression with success");
            }
            
        }
    }

}