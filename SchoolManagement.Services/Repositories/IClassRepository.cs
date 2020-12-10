using SchoolManagement.DOMAIN;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Repositories
{
    interface IClassRepository
    {
        Task<IEnumerable<Class>> GetAll();
        Task<Class> Add(Class classToAdd);
        Task<Class> GetClassById(int id);
    }
}
