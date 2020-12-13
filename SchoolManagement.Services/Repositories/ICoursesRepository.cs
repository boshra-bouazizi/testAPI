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
        Task<bool> AddCourses(Courses coursesToAdd);
        Task<Courses> GetCourses(int id);
        Task<bool> UpdateCourses(Courses coursesPut);
        Task<bool>DeleteCourses(Courses coursesToDelete);
    }

}
