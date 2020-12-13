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
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] StudentModel student)
        {
            var studentToAdd = new Student()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                BirthDate = student.BirthDate
            };

            var addedStudent = await _studentRepository.AddStudent(studentToAdd);

            if (addedStudent == false)
            {
                return BadRequest("Failure to add item");
            }
            else
            {
                return Ok("Addition successfully");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudent(int id)
        {

            var studentToReturn = await _studentRepository.GetStudent(id);
            if (studentToReturn==null)
            {
                return NotFound("Not found item.");
            }
            else 
            {
                return Ok(studentToReturn);
            }

            
        }
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Student> studentList = await _studentRepository.GetAll();
            return Ok(studentList);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return NotFound("No founded item.");
            }
            else
            {
                await _studentRepository.UpdateStudent(student);
                return Ok("ok");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            Student studentToDelete = await _studentRepository.GetStudent(id);

            if (studentToDelete == null)
            {
                return NotFound("Not founded item");
            }
            else 
            {
                await _studentRepository.DeleteStudent(studentToDelete);
                return Ok("Suppression with success");
            }
        }
    }
}
