using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dapper.Sql.Queries
{
    public static class CourseQueries
    {
        public static string CourseAgeGt20 => @"SELECT DISTINCT c.*
                                                FROM public.course AS c
                                                JOIN public.student_course AS sc ON c.courseid = sc.courseid
                                                JOIN public.student AS s ON s.studentid = sc.studentid
                                                WHERE s.age > 20";
        public static string AddCourse => @" INSERT INTO public.course (courseid, name, description, department)
                                             VALUES (@CourseId, @CourseName, @CourseDescription, @CourseDepartment);";
        public static string DeleteCourse => "DELETE FROM Course WHERE courseid = @courseid";

    }
}
