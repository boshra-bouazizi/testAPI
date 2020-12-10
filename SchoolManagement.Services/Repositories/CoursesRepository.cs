using Microsoft.EntityFrameworkCore;
using SchoolManagement.DATA;
using SchoolManagement.DOMAIN;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Repositories
{
    public class CoursesRepository
    {

        private readonly SchoolManagementContext _context;

        public CoursesRepository(SchoolManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Courses>> GetAll()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Courses> GetCoursesById(int id)
        {
            return await _context.Courses.FirstOrDefaultAsync(Courses => Courses.Id == id);
        }

        public async Task<Courses> Add(Courses coursesToAdd)
        {
            //if(ClassToAdd == null)
            //{
            //    return  ArgumentNullException();
            //}

            var courses = new Courses()
            {
                Name = coursesToAdd.Name,
                ClassId = coursesToAdd.ClassId
            };
            // 1- Ajout de l'entité crée au niveau de la memoire temporelle 
            _context.Add(courses);

            // 2- Persist changes to the database

            if (await _context.SaveChangesAsync() >= 0)
            {
                return courses;
            }
            else
            {
                return null;
            }

        }


    }

}
    

