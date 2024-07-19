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
    public class CourseRepository : ICourseRepository
    {
        private readonly IConfiguration _configuration;

        public CourseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private IDbConnection Connection => new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));

        public async Task<IEnumerable<Course>> GetCourseStudentOver20()
        {
            var query = CourseQueries.CourseAgeGt20;
            using (var connection = Connection)
            {
                var result = await connection.QueryAsync<Course>(query);
                return result;
            }
        }

        public async Task AddCourse(Course course)
        {
            var query = CourseQueries.AddCourse;
            using (var connection = Connection)
            {
                await connection.ExecuteAsync(query, new
                {
                    CourseId = course.CourseId,
                    CourseName = course.Name,
                    CourseDescription = course.Description,
                    CourseDepartment = course.Department
                });
            }
        }

        public async Task DeleteCourse(int courseid)
        {
            var query = CourseQueries.DeleteCourse;
            using (var connection = Connection)
            {
                await connection.ExecuteAsync(query, new {courseid});
            }
        }
    }
}
