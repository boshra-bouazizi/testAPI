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

        public async Task<IActionResult> AddStudent([FromBody]StudentModel student)
        {
            var studentToAdd = new Student()
            {
                FirstName = student.FirstName,
                LastName = student.LastName
            };

            var addedStudent = await _studentRepository.Add(studentToAdd);

            if (addedStudent == null)
            {
                return BadRequest("Une erreur a surevenue");
            }
            else
            {
                return Ok(addedStudent);
            }
        }

        [HttpGet("GetStudent/{id:int}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var studentToReturn = await _studentRepository.GetStudentById(id);
            return Ok(studentToReturn);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Student> studentList = await _studentRepository.GetAll();
            return Ok(studentList);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody]Student student) 
        {
            var studentToUpdate = await _studentRepository.UpdateStudent(student);
            
            return Ok(studentToUpdate);
        }
        [HttpDelete("GetStudent/{id:int}")]
        public async Task DeleteStudent([FromBody] Student student)
        {
             await _studentRepository.DeleteStudentById(student.Id);  
        }
    }
}
