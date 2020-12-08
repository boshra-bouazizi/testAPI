using Microsoft.EntityFrameworkCore;
using SchoolManagement.DOMAIN;

namespace SchoolManagement.DATA
{
    public class SchoolManagementContext : DbContext
    {
        public SchoolManagementContext(DbContextOptions<SchoolManagementContext> options) : base (options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
    }
}
