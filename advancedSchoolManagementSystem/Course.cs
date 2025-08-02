using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advancedSchoolManagementSystem
{
    internal class Course
    {
        private int _courseID;
        private string _courseName;
        private int _courseCredits;

        public int CourseID { get { return _courseID; } set { _courseID = value; } }
        public string CourseName { get { return _courseName; } set { _courseName = value; } }
        public int CourseCredits { get { return _courseCredits; } set { _courseCredits = value; } }

        public override string ToString()
        {
            return $"Course ID: {CourseID}, Name: {CourseName}, Credits: {CourseCredits}";
        }
    }
}
