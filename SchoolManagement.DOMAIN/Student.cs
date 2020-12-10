using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.DOMAIN
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string StudentCardId { get; set; }
        public virtual ICollection<StudentClass> StudentClasses { get; set; }
    }
}
