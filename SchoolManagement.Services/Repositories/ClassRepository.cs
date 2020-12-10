using Microsoft.EntityFrameworkCore;
using SchoolManagement.DATA;
using SchoolManagement.DOMAIN;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Repositories
{
    class ClassRepository
    {
        private readonly SchoolManagementContext _context;

        public ClassRepository(SchoolManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Class>> GetAll()
        {
            return await _context.Classes.ToListAsync();
        }

        public async Task<Class> GetClassById(int id)
        {
            return await _context.Classes.FirstOrDefaultAsync(Class => Class.Id == id);
        }

        public async Task<Class> Add(Class ClassToAdd)
        {
            //if(ClassToAdd == null)
            //{
            //    return  ArgumentNullException();
            //}

            var Class = new Class()
            {
                Name = ClassToAdd.Name,
                Division = ClassToAdd.Division
            };
            // 1- Ajout de l'entité crée au niveau de la memoire temporelle 
            _context.Add(Class);

            // 2- Persist changes to the database

            if (await _context.SaveChangesAsync() >= 0)
            {
                return Class;
            }
            else
            {
                return null;
            }

        }


    }
}
