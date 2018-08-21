using System.Threading.Tasks;
using PluralsightLive.Domain.Requests;

namespace PluralsightLive.Infrastructure.Repositories
{
    public interface ICoursesRepository
    {
        Task<(bool success, string message)> AddStudentToCourseAsync(AddStudentRequest addStudentRequest);
        Task<bool> CourseExists(int courseId);
        Task<bool> CourseIsFull(int courseId);
    }
}