using Microsoft.EntityFrameworkCore;
using SchoolManagement.DATA;
using SchoolManagement.DOMAIN;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolManagementContext _context;

        public StudentRepository(SchoolManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
           return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(student => student.Id == id);
        }

        public async Task<Student> Add(Student studentToAdd)
        {
            //if(studentToAdd == null)
            //{
            //    return  ArgumentNullException();
            //}

            var student = new Student()
            {
                FirstName = studentToAdd.FirstName,
                LastName = studentToAdd.LastName
            };
            // 1- Ajout de l'entité crée au niveau de la memoire temporelle 
            _context.Add(student);

            // 2- Persist changes to the database

            if (await _context.SaveChangesAsync() >= 0)
            {
                return student;
            }
            else
            {
                return null;
            }

        }

        public async Task<Student> UpdateStudent(Student newStudent)
        {
            var studentToUpdate = await GetStudentById(newStudent.Id);

            studentToUpdate.LastName = newStudent.LastName;
            studentToUpdate.FirstName = newStudent.FirstName;
            studentToUpdate.BirthDate = newStudent.BirthDate;
            studentToUpdate.StudentCardId = newStudent.StudentCardId;
            return(studentToUpdate);
             
        }

        public async Task<bool> DeleteStudentById(int id)
        {
            var studentToDelete = await GetStudentById(id);
            var listOfStudents=await _context.Students.ToListAsync();
            listOfStudents.Remove(studentToDelete);
            if (await _context.SaveChangesAsync() >= 0)
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
