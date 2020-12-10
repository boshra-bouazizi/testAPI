using System;
using System.Collections.Generic;
using System.Text;
namespace SchoolManagement.DOMAIN
{
	public class Class
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Division { get; set; }
		public virtual ICollection<StudentClass> StudentClasses { get; set; }
	}
}
