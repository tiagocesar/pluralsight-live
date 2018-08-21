using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PluralsightLive.Domain.Requests;
using PluralsightLive.Domain.Responses;
using PluralsightLive.Infrastructure.Repositories;

namespace PluralsightLive.Application.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly ICoursesRepository _coursesRepository;

        private readonly ILogger<CoursesService> _logger;

        public CoursesService(ICoursesRepository coursesRepository, ILogger<CoursesService> logger)
        {
            _coursesRepository = coursesRepository;

            _logger = logger;
        }

        private async Task<(bool success, string message)> ValidateCourseInfoAsync(int courseId)
        {
            if (await _coursesRepository.CourseExists(courseId))
            {
                _logger.LogError("The course with Id {courseId} does not exist", courseId);

                return (false, $"The course with id {courseId} was not found");
            }

            if (!await _coursesRepository.CourseIsFull(courseId)) return (true, "");

            _logger.LogError("The course with Id {courseId} is full", courseId);

            return (false, $"The course with id {courseId} has no free seatings");
        }

        private async Task<(bool success, string message)> ProceedWithStudentEnrollingAsync(
            AddStudentRequest addStudentRequest)
        {
            var result = await _coursesRepository.AddStudentToCourseAsync(addStudentRequest);

            return (result, "Student enrolled successfully");
        }

        public async Task<DefaultResponse> AddStudentToCourseAsync(AddStudentRequest addStudentRequest)
        {
            _logger.LogInformation("Started service to add a new student to a course");
            _logger.LogDebug("Payload: {@addStudentRequest}", addStudentRequest);

            var validationResult = await ValidateCourseInfoAsync(addStudentRequest.CourseId);

            if (!validationResult.success)
            {
                return new DefaultResponse
                {
                    Success = validationResult.success,
                    Message = validationResult.message
                };
            }

            var result = await ProceedWithStudentEnrollingAsync(addStudentRequest);

            return new DefaultResponse
            {
                Success = result.success,
                Message = result.message
            };
        }
    }
}