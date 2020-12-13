using Microsoft.EntityFrameworkCore;
using SchoolManagement.DATA;
using SchoolManagement.DOMAIN;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Repositories
{
    public class CoursesRepository: ICoursesRepository
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

        public async Task<Courses> GetCourses(int id)
        {
            return await _context.Courses.FirstOrDefaultAsync(Courses => Courses.Id == id);
        }

        public async Task<bool> AddCourses(Courses coursesToAdd)
        {
            var courses = new Courses()
            {
                Name = coursesToAdd.Name
            };

            
            if (coursesToAdd == null)
            {
                return false;
            }

            else 
            {
                _context.Add(courses);
                await _context.SaveChangesAsync();
                return true;
            }

        }

        public async Task<bool> UpdateCourses(Courses coursesPut)
        {
            Courses coursesToUpdate = await GetCourses(coursesPut.Id); 
	    if(coursesToUpdate==null)
	    {
		return false;
	    }
	else
	{
	      coursesToUpdate.Name = coursesPut.Name;
            //coursesToUpdate.ClassId = coursesPut.ClassId;
	      await _context.SaveChangesAsync();
	      return true;

	}

        }

        public async Task <bool>DeleteCourses(Courses coursesToDelete)
        {

if(coursesToDelete==null)
{return false;}
else
{
_context.Courses.Remove(coursesToDelete);
                await _context.SaveChangesAsync();
                return true;

}
            
        }

       
    }

}
    

