using System.Threading.Tasks;
using PluralsightLive.Domain.Models;
using PluralsightLive.Domain.Requests;

namespace PluralsightLive.Infrastructure.Repositories
{
    public class CoursesRepository : ICoursesRepository
    {
        public Task<(bool success, string message)> AddStudentToCourseAsync(AddStudentRequest addStudentRequest)
        {
            var student = new Student
            {
                Name = addStudentRequest.StudentName,
                Email = addStudentRequest.StudentEmail
            };
            
            throw new System.NotImplementedException();
        }

        public Task<bool> CourseExists(int courseId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CourseIsFull(int courseId)
        {
            throw new System.NotImplementedException();
        }
    }
}