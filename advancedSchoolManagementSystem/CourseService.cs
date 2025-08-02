using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advancedSchoolManagementSystem
{
    internal class CourseService : ICourseService
    {
        #region AvailabeCourses
        public static List<Course> availableCourses = new List<Course>
        {
            new Course { CourseID = 1, CourseName = "MATH101", CourseCredits = 3 },
            new Course { CourseID = 2, CourseName = "IT101", CourseCredits = 3 },
            new Course { CourseID = 3, CourseName = "PHYSICS102", CourseCredits = 3 },
            new Course { CourseID = 4, CourseName = "ENGLISH102", CourseCredits = 2 },
            new Course { CourseID = 5, CourseName = "PROGRAMMING", CourseCredits = 5 },
        };
        #endregion

        #region ShowCourses
        public void ShowCourses()
        {
            Console.Clear();
            ConsoleStyler.PrintTitle("available courses");
            Console.WriteLine();

            foreach (var course in availableCourses)
            {
                ConsoleStyler.PrintMenuOption(course);
            }
            Console.WriteLine();
        }
        #endregion

        #region GetCourseByID
        public Course GetCourseByID(int id)
        {
            foreach (var course in availableCourses)
            {
                if (course.CourseID == id)
                    return course;
            }
            return null;
        }
        #endregion
    }
}
