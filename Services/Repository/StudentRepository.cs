using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Application;
using Dapper.Core.Entities;
using Dapper.Sql.Queries;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Dapper.Infrastructure.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IConfiguration _configuration;
        private IDbConnection Connection => new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));


        public StudentRepository(IConfiguration configuration)
        {
            _configuration = configuration; 
        }

        public async Task AddStudent(Student student)
        {
            var query = StudentQueries.AddStudent;
            using (var connection = Connection)
            {
                await connection.ExecuteAsync(query, new
                {
                    StudentId = student.StudentId,
                    StudentPhone = student.StudentPhone,
                    Age = student.Age,
                    Fullname = student.fullname
                });
            }
        }

        public async Task DeleteStudent(int studentid)
        {
            var query = StudentQueries.DeleteStudent;
            using (var connection = Connection)
            {
                await connection.ExecuteAsync(query, new {studentid});
            }
        }
    }
}
