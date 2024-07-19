using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Application;
using Dapper.Core.Entities;

namespace Dapper.Application.Application
{
    public interface ICourseRepository 
    {
        Task<IEnumerable<Course>> GetCourseStudentOver20();
        Task AddCourse(Course course);
        Task DeleteCourse(int courseid);
    }
}
