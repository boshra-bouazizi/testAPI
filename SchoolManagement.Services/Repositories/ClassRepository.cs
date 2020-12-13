using Microsoft.EntityFrameworkCore;
using SchoolManagement.DATA;
using SchoolManagement.DOMAIN;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Repositories
{
    public class ClassRepository : IClassRepository
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

        public async Task<Class> GetClass(int id)
        {
            return await _context.Classes.FirstOrDefaultAsync(_class => _class.Id == id);
        }

        public async Task<bool> AddClass(Class classToAdd)
        {

            var _class = new Class()
            {
                Name = classToAdd.Name,
                Division = classToAdd.Division
            };

            if (classToAdd == null)
            {
                return false;
            }

            else
            {
                _context.Add(_class);
                await _context.SaveChangesAsync();
                return true;
            }

        }

        public async Task<bool> UpdateClass(Class _class)
        {
            var classToUpdate = await GetClass(_class.Id);
            if (classToUpdate == null)

            {
                return false;
            }
            else 
            {
                classToUpdate.Name = _class.Name;
                classToUpdate.Division = _class.Division;
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> DeleteClass(Class classToDelete)
        {
            if (classToDelete==null) 
            {
                return false;
            }
            else 
            {
                _context.Classes.Remove(classToDelete);
                   await _context.SaveChangesAsync();
                return true;
            }
        }


    }
}
