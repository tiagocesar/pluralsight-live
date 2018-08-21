using System.Threading.Tasks;
using PluralsightLive.Domain.Requests;

namespace PluralsightLive.Infrastructure.Repositories
{
    public interface ICoursesRepository
    {
        Task<bool> AddStudentToCourseAsync(AddStudentRequest addStudentRequest);
        Task<bool> CourseExists(int courseId);
        Task<bool> CourseIsFull(int courseId);
    }
}