using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PluralsightLive.Application.Services;
using PluralsightLive.Domain.Requests;

namespace PluralsightLive.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesService _coursesService;

        private readonly ILogger<CoursesController> _logger;

        public CoursesController(ICoursesService coursesService, ILogger<CoursesController> logger)
        {
            _coursesService = coursesService;

            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddStudentToCourse([FromBody] AddStudentRequest addStudentRequest)
        {
            _logger.LogInformation("Received request to add a new student to a course");
            _logger.LogDebug("Payload: {@addStudentRequest}", addStudentRequest);

            try
            {
                var result = await _coursesService.AddStudentToCourseAsync(addStudentRequest);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(500, e, "Failure when trying to add a new student to a course");
                
                throw;
            }
        }
    }
}