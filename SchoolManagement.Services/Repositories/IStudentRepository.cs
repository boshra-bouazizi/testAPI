using SchoolManagement.DOMAIN;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> Add(Student studentToAdd);
        Task<Student> GetStudentById(int id);
    }
}