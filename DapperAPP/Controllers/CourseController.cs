using Dapper.Application.Application;
using Dapper.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DapperAPI.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpPost("AddCourse")]

        public async Task<IActionResult> AddCourse(Course course)
        {
            await _courseRepository.AddCourse(course);
            return Ok();
        }

        [HttpDelete("DeleteCourse")]

        public async Task<IActionResult> DeleteCourse(int courseid)
        {
            await _courseRepository.DeleteCourse(courseid);
            return Ok();
        }
    }
}
