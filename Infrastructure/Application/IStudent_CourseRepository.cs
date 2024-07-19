using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Core.Entities;

namespace Dapper.Application.Application
{
    public interface IStudent_CourseRepository
    {
        Task AssignCourseStudent(int studentid, int courseid);
        Task RemoveStudentFromCourse(int courseid, int studentid);
        Task UpdateStudentCourse(int newcourseid, int oldcourseid, int oldstudentid);
    }
}
