using System;
using System.Collections.Generic;
using advancedSchoolManagementSystem;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace advancedSchoolManagementSystem
{

    internal class Program
    {
        static void Main(string[] args)
        {
            var studentService = new StudentService();
            studentService.LoadStudentsFromJsonFile("students.json");

            new UIApp(new StudentService(), new AuthService(studentService), new CourseService(), null).ShowMainMenu();
        }
    }
}