using System.Threading.Tasks;
using PluralsightLive.Domain.Requests;
using PluralsightLive.Domain.Responses;

namespace PluralsightLive.Application.Services
{
    public interface ICoursesService
    {
        Task<DefaultResponse> AddStudentToCourseAsync(AddStudentRequest addStudentRequest);
    }
}