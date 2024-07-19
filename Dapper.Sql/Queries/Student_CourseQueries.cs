using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Sql.Queries
{
    public static class Student_CourseQueries
    {

        public static string AssignCourseStudent => @"
            INSERT INTO student_course (studentid, courseid)
            VALUES (@studentid, @courseid)";
        public static string RemoveStudentFromCourse => @"
            DELETE FROM student_course 
            WHERE courseid = @courseid AND studentid = @studentid;";
        public static string UpdateCourseStudent => @"UPDATE student_course
                                                    SET courseid = @newCourseId
                                                    WHERE studentid = @studentid
                                                        AND courseid = @oldCourseId;";



    }
}

