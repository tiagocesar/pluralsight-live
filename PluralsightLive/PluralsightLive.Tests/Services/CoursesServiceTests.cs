using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using PluralsightLive.Application.Services;
using PluralsightLive.Domain.Requests;
using PluralsightLive.Infrastructure.Repositories;
using Xunit;

namespace PluralsightLive.Tests.Services
{
    public class CoursesServiceTests
    {
        private static AddStudentRequest GetStudentRequest => new AddStudentRequest
        {
            CourseId = 1,
            StudentName = "John Doe",
            StudentEmail = "me@someone.com"
        };

        [Fact]
        public async Task InvalidCourseShouldReturnFailure()
        {
            var courseRepositoryMock = new Mock<ICoursesRepository>();

            courseRepositoryMock.Setup(x => x.CourseExists(It.IsAny<int>())).ReturnsAsync(false);

            var loggerMock = new Mock<ILogger<CoursesService>>();

            var coursesService = new CoursesService(courseRepositoryMock.Object, loggerMock.Object);

            var result = await coursesService.AddStudentToCourseAsync(GetStudentRequest);

            Assert.False(result.Success);
        }

        [Fact]
        public async Task FullCourseShouldReturnFailure()
        {
            var courseRepositoryMock = new Mock<ICoursesRepository>();

            courseRepositoryMock.Setup(x => x.CourseIsFull(It.IsAny<int>())).ReturnsAsync(false);

            var loggerMock = new Mock<ILogger<CoursesService>>();

            var coursesService = new CoursesService(courseRepositoryMock.Object, loggerMock.Object);

            var result = await coursesService.AddStudentToCourseAsync(GetStudentRequest);

            Assert.False(result.Success);
        }

        [Fact]
        public async Task FailureOnAddingStudentToCourseShouldReturnFailure()
        {
            var courseRepositoryMock = new Mock<ICoursesRepository>();

            courseRepositoryMock.Setup(x => x.CourseExists(It.IsAny<int>())).ReturnsAsync(true);
            courseRepositoryMock.Setup(x => x.CourseIsFull(It.IsAny<int>())).ReturnsAsync(true);
            courseRepositoryMock.Setup(x => x.AddStudentToCourseAsync(It.IsAny<AddStudentRequest>()))
                .ReturnsAsync((false, ""));

            var loggerMock = new Mock<ILogger<CoursesService>>();

            var coursesService = new CoursesService(courseRepositoryMock.Object, loggerMock.Object);

            var result = await coursesService.AddStudentToCourseAsync(GetStudentRequest);

            Assert.False(result.Success);
        }
    }
}