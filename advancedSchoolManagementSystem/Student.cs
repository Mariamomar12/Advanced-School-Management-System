using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advancedSchoolManagementSystem
{
    internal class Student
    {
        private int _studentID;
        private string _studentName;
        private string _studentPassword;

        public int ID { get { return _studentID; } set { _studentID = value; } }
        public string Name { get { return _studentName; } set { _studentName = value; } }
        public string Password { get { return _studentPassword; } set { _studentPassword = value; } }
        public List<Course> enrolledCourses { get; set; } = new List<Course>();
    }
}
