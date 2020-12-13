using System;
using System.Collections.Generic;
using System.Text;
namespace SchoolManagement.DOMAIN
{
    public class Courses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }
    }
}


