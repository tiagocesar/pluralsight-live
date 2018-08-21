using System.Collections.Generic;

namespace PluralsightLive.Domain.Models
{
    public class Course
    {
        public int Id { get; set; }
        public Lecturer Lecturer { get; set; }
        public int MaximumNumberOfStudents { get; set; }
        
        public IEnumerable<Student> Students { get; set; }
    }
}