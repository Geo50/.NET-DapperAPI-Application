using Application.Application;
using Dapper.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DapperAPI.Controllers
{
    public class StudentController : Controller
    {

        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpPost("AddStudent")]

        public async Task<IActionResult> AddStudent(Student student)
        {
            await _studentRepository.AddStudent(student);
            return Ok();
        }

        [HttpDelete("DeleteStudent")]

        public async Task<IActionResult> DeleteStudent(int studentid)
        {
            {
                await _studentRepository.DeleteStudent(studentid);
                return Ok();
            }
        }
    }
}
