using Microsoft.EntityFrameworkCore;
using SchoolManagement.DOMAIN;
using System;

namespace SchoolManagement.DATA
{
    public class SchoolManagementContext : DbContext
    {
        public SchoolManagementContext(DbContextOptions<SchoolManagementContext> options) : base (options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentClass>() // we have a class result of two classes Student and Class
                .HasKey(sc => new { sc.StudentId, sc.ClassId });  // has as keys the two Id of the two classes Student and Class

            modelBuilder.Entity<StudentClass>()// 
                .HasOne(sc => sc.Student)// We have an instance of a Student inside the StudentClass
                .WithMany(s => s.StudentClasses) // We have an instance of Student
                .HasForeignKey(sc => sc.StudentId);  // and he has a foreign key called StudentId

            modelBuilder.Entity<StudentClass>()
                .HasOne(cl => cl.Class)// We have an instance of a Class
                .WithMany(c => c.StudentClasses) // We have an instance of Student
                .HasForeignKey(cl => cl.ClassId);// We have a foreign Key called ClassId
        }

    }
}
