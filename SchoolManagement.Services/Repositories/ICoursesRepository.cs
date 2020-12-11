using SchoolManagement.DOMAIN;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Repositories
{
    public interface ICoursesRepository
    {
        Task<IEnumerable<Courses>> GetAll();
        Task<Courses> Add(Courses coursesToAdd);
        Task<Courses> GetCoursesById(int id);
        Task<Courses> UpdateCourses(Courses newCourses);
        Task DeleteCourses(int id);
    }

}
