using Microsoft.EntityFrameworkCore;
using SchoolManagement.DATA;
using SchoolManagement.DOMAIN;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Repositories
{
    class ClassRepository:IClassRepository
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

        public async Task<Class> Add(Class classToAdd)
        {
            //if(ClassToAdd == null)
            //{
            //    return  ArgumentNullException();
            //}

            var _class = new Class()
            {
                Name = classToAdd.Name,
                Division = classToAdd.Division
            };
            // 1- Ajout de l'entité crée au niveau de la memoire temporelle 
            _context.Add(_class);

            // 2- Persist changes to the database

            if (await _context.SaveChangesAsync() >= 0)
            {
                return _class;
            }
            else
            {
                return null;
            }

        }

        public async Task<Class> UpdateClass(Class newClass)
        {
            var classToUpdate = await GetClassById(newClass.Id);

            classToUpdate.Name = newClass.Name;
            classToUpdate.Division = newClass.Division;

            return (classToUpdate);

        }

        public async Task DeleteClass(int id)
        {
            var classToDelete = await GetClassById(id);
            var listOfClasses = await _context.Classes.ToListAsync();
            listOfClasses.Remove(classToDelete);
        }


    }
}
