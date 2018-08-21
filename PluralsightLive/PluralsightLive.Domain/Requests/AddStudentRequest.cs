namespace PluralsightLive.Domain.Requests
{
    public class AddStudentRequest
    {
        public int CourseId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
    }
}