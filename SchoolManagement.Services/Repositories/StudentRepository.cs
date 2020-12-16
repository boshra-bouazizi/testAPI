using Microsoft.EntityFrameworkCore;
using SchoolManagement.DATA;
using SchoolManagement.DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            return await _context.Students
                      .Include(s => s.StudentClasses)
                      .ThenInclude(sc => sc.Classes).ToListAsync();

        }

        public async Task<Student> GetStudent(int id)
        {
            return await _context.Students
                                          .FirstOrDefaultAsync(student => student.Id == id);
        }

        public async Task<bool> AddStudent(Student studentToAdd)
        {
            var student = new Student()
            {
                FirstName = studentToAdd.FirstName,
                LastName = studentToAdd.LastName,
                BirthDate = studentToAdd.BirthDate,
            };
            if (studentToAdd == null)
            {
                return false;
            }   
            else
            {
                var classE = _context.Classes.FirstOrDefaultAsync(c => c.Id == student.Id);

                var studentClass = new StudentClass()

                {
                    Student = student,
                    Classes = await classE
                };
                 _context.StudentClasses.Add(studentClass);
                _context.Students.Add(studentToAdd);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            Student studentToUpdate = await GetStudent(student.Id);
            if (studentToUpdate == null)
            {
                return false;
            }

            else
            {
                studentToUpdate.LastName = student.LastName;
                studentToUpdate.FirstName = student.FirstName;
                studentToUpdate.BirthDate = student.BirthDate;
                studentToUpdate.StudentCardId = student.StudentCardId;
                await _context.SaveChangesAsync();
                return true;
            }

        }

        public async Task<bool> DeleteStudent(Student studentToDelete)
        {
            if (studentToDelete == null)
            {
                return false;
            }
            else
            {
                _context.Students.Remove(studentToDelete);
                await _context.SaveChangesAsync();
                return true;
            }

        }
    }
}
