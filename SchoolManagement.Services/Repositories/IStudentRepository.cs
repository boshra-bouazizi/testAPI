using SchoolManagement.DOMAIN;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAll();
        Task<bool> AddStudent(Student studentToAdd);
        Task<Student> GetStudent(int id);
        Task<bool> UpdateStudent(Student student);
        Task<bool> DeleteStudent(Student studentToDelete);
    }
}