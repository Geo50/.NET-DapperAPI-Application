using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Core.Entities;

namespace Application.Application
{
    public interface IStudentRepository
    {
        Task AddStudent(Student student);
        Task DeleteStudent(int studentid);

    }
}
    