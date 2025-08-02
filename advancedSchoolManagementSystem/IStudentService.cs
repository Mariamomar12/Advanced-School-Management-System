using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace advancedSchoolManagementSystem
{
    internal interface IStudentService
    {
        void AddStudent(Student student);
        bool EnrollingInCourses(int courseID, int studentID);
        void RemoveCourseFromStudent(int courseID, int studentID);
        void ConfirmRemoveCourse(int courseID, int studentID);
        void DeleteStudent(int studentID);
        void ConfirmDeleteStudent(int studentID);
        bool IsIDTaken(int id);
        void DisplayStudentInfo(Student s);
        Student GetStudentByID(int id);
        void SaveStudentsToJsonFile(string filePath);
        void LoadStudentsFromJsonFile(string filePath);
    }
}
