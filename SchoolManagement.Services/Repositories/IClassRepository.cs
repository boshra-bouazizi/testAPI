using SchoolManagement.DOMAIN;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Repositories
{
    public interface IClassRepository
    {
        Task<IEnumerable<Class>> GetAll();
        Task<bool> AddClass(Class classToAdd);
        Task<Class> GetClass(int id);
        Task<bool> UpdateClass(Class _class);
        Task<bool> DeleteClass(Class classToDelete);
    }
}
