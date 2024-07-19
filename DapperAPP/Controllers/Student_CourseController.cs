using Application.Application;
using Dapper.Application.Application;
using Dapper.Core.Entities;
using Dapper.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DapperAPI.Controllers
{
    public class Student_CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IStudent_CourseRepository _student_courseRepository;
        private readonly IStudentRepository _studentRepository;

        public Student_CourseController(ICourseRepository courseRepository, IStudent_CourseRepository student_CourseRepository, IStudentRepository studentRepository)
        {
            _courseRepository = courseRepository;
            _student_courseRepository = student_CourseRepository;
            _studentRepository = studentRepository;
        }

        //***************************** STUDENT_COURSE TABLE QUERIES ***************************** 

        [HttpGet("GetCourseAgeGt20")]

        public async Task<ActionResult<IEnumerable<Course>>> GetCourseStudentOver20()
        {
            var courses = await _courseRepository.GetCourseStudentOver20();
            return Ok(courses);
        }

        [HttpPost("AssignCourseStudent")]
        public async Task<IActionResult> AssignCourseStudent(int studentid, int courseid)
        {
             await _student_courseRepository.AssignCourseStudent(studentid, courseid);

            return Ok();
        }


        [HttpDelete("RemoveStudentFromCourse")]
        public async Task<ActionResult> RemoveStudentFromCourse(int courseid, int studentid)
        {
            await _student_courseRepository.RemoveStudentFromCourse(courseid, studentid);
            return Ok();
        }

        [HttpPut("UpdateStudentCourse")]
        public async Task<IActionResult> UpdateStudentCourse(int studentid, int oldcourseid, int newcourseid)
        {
            await _student_courseRepository.UpdateStudentCourse(studentid, oldcourseid, newcourseid);
            return Ok();
        }

        
     }
}
