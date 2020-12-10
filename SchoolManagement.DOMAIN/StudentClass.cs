namespace SchoolManagement.DOMAIN
{
    public class StudentClass
    {
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public virtual Student Student { get; set;}
        public virtual Class Class { get; set; }
    }
}

