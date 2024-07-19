using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Sql.Queries
{
    public static class StudentQueries
    {
        public static string AddStudent => @"
            INSERT INTO public.Student (studentid, studentphone, age, fullname)
            VALUES (@studentid, @studentphone, @age, @fullname);";

        public static string DeleteStudent => "DELETE FROM Student WHERE StudentId = @StudentId";
    }
}
