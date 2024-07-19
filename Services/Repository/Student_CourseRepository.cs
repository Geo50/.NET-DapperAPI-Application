using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Application.Application;
using Dapper.Core.Entities;
using Dapper.Sql.Queries;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Dapper.Infrastructure.Repository
{
    public class Student_CourseRepository : IStudent_CourseRepository
    {
        private readonly IConfiguration _configuration;

        public Student_CourseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection Connection => new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));

        public async Task AssignCourseStudent(int studentid, int courseid)
        {
            var query = Student_CourseQueries.AssignCourseStudent;
            using (var connection = Connection)
            {
                 await connection.ExecuteAsync(query, new { studentid, courseid });
            }
        }
        public async Task RemoveStudentFromCourse(int courseid, int studentid)
        {
            var query = Student_CourseQueries.RemoveStudentFromCourse;
            using (var  connection = Connection)
            {
                 await connection.ExecuteAsync(query, new { courseid, studentid });
            }
        }
        public async Task UpdateStudentCourse(int studentId,  int oldCourseId , int newCourseId)
        {
            var query = Student_CourseQueries.UpdateCourseStudent;
            using (var connection = Connection)
            {
                await connection.ExecuteAsync(query, new
                {
                    oldCourseId,
                    studentId,
                    newCourseId
                });
            }
        }



    }
}
