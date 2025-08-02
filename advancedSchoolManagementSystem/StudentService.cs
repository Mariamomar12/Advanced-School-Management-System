using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace advancedSchoolManagementSystem
{
    internal class StudentService : IStudentService
    {
        public List<Student> students = new List<Student>();
        private const string FilePath = "students.json";

        #region AddStudent
        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        #endregion

        #region EnrollingInCourses
        public bool EnrollingInCourses(int courseID, int studentID)
        {
            try
            {
                var student = GetStudentByID(studentID);
                if (student == null)
                {
                    ConsoleStyler.PrintError("Student not found");
                    return false;
                }

                Course course = null;
                foreach (var c in CourseService.availableCourses)
                {
                    if (c.CourseID == courseID)
                    {
                        course = c;
                        break;
                    }
                }

                if (course == null)
                {
                    ConsoleStyler.PrintError("Course not found");
                    return false;
                }

                foreach (var c in student.enrolledCourses)
                {
                    if (c.CourseID == courseID)
                    {
                        ConsoleStyler.PrintWarning("Already enrolled in this course.");
                        return false;
                    }
                }

                if (student.enrolledCourses.Count >= 5)
                {
                    ConsoleStyler.PrintError("You can’t enroll in more than 5 courses.");
                    return false;
                }

                student.enrolledCourses.Add(course);
                SaveStudentsToJsonFile("students.json");
                ConsoleStyler.PrintSuccess("Enrolled successfully.");
                return true;
            }
            catch (Exception ex)
            {
                ConsoleStyler.PrintError($"An error occurred: {ex.Message}");
                return false;
            }
        }
        #endregion

        #region RemoveCourseFromStudent
        public void RemoveCourseFromStudent(int courseID, int studentID)
        {
            try
            {
                var student = GetStudentByID(studentID);

                if (student.enrolledCourses.Count == 0)
                {
                    ConsoleStyler.PrintError("You are not enrolled in any courses to remove.");
                }
                else if (student != null && student.enrolledCourses.Count != 0)
                {
                    for (int i = 0; i < student.enrolledCourses.Count; i++)
                    {
                        if (student.enrolledCourses[i].CourseID == courseID)
                        {
                            student.enrolledCourses.RemoveAt(i);
                            ConsoleStyler.PrintError("Course successfully removed.");
                            break;
                        }
                    }
                }
                else
                {
                    ConsoleStyler.PrintWarning("Course not found in your enrolled courses");
                }
            }
            catch (Exception ex)
            {
                ConsoleStyler.PrintError($"An error occured while removing the coures: {ex.Message}");
            }
        }
        #endregion

        #region ConfirmRemoveCourse
        public void ConfirmRemoveCourse(int courseID, int studentID)
        {
            Console.Clear();
            ConsoleStyler.PrintWarning($"Are you sure you want to remove CourseID {courseID} from StudentID {studentID}? (y/n): ");
            string confirm = Console.ReadLine().ToLower().Trim();
            if (confirm == "y")
            {
                RemoveCourseFromStudent(courseID, studentID);
                SaveStudentsToJsonFile("students.json"); 
            }
            else
            {
                ConsoleStyler.PrintWarning("Course removal cancelled.");
            }
        }
        #endregion

        #region DeleteStudent
        public void DeleteStudent(int studentID)
        {
            try
            {
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].ID == studentID)
                    {
                        students.RemoveAt(i);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ConsoleStyler.PrintError($"An error occured while removing the Student: {ex.Message}");
            }
        }
        #endregion

        #region ConfirmDeleteStudent
        public void ConfirmDeleteStudent(int studentID)
        {
            Console.Clear();
            ConsoleStyler.PrintWarning($"Are you sure you want to delete student with ID {studentID}? (y/n): ");
            string confirm = Console.ReadLine().ToLower().Trim();
            if (confirm == "y")
            {
                DeleteStudent(studentID);
                SaveStudentsToJsonFile("students.json");

                ConsoleStyler.PrintError("Student successfully deleted.");
            }
            else
            {
                ConsoleStyler.PrintWarning("Deletion cancelled.");
            }
        }
        #endregion

        #region IsIDTaken
        public bool IsIDTaken(int id)
        {
            foreach (var s in students)
            {
                if (s.ID == id) return true;
            }
            return false;
        }
        #endregion

        #region DisplayStudentInfo
        public void DisplayStudentInfo(Student s)
        {
            Console.Clear();
            ConsoleStyler.PrintMenuOption($"Student Name: {s.Name}");
            ConsoleStyler.PrintMenuOption($"Student ID: {s.ID}");
            Console.WriteLine();
            ConsoleStyler.PrintTitle("Enrolled Courses");
            Console.WriteLine();
            if (s.enrolledCourses.Count == 0)
            {
                ConsoleStyler.PrintMenuOption("You are not enrolled in any courses.");
            }
            else
            {
                foreach (var c in s.enrolledCourses)
                {
                    ConsoleStyler.PrintMenuOption($"- {c.CourseName} ({c.CourseCredits} credits)");
                }
            }

            ConsoleStyler.WaitForKey("\nPress any key to return to the menu...");
        }
        #endregion

        #region GetStudentByID
        public Student GetStudentByID(int id)
        {
            foreach (var s in students)
            {
                if (s.ID == id) return s;
            }
            return null;
        }
        #endregion

        #region SaveStudentToJsonFile
        public void SaveStudentsToJsonFile(string filePath)
        {
            string json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
        #endregion

        #region LoadStudentsFromJsonFile
        public void LoadStudentsFromJsonFile(string filePath)
        {
            if (!File.Exists(filePath)) return;

            string json = File.ReadAllText(filePath);
            var loadedStudents = JsonSerializer.Deserialize<List<Student>>(json);

            if (loadedStudents != null)
            {
                students = loadedStudents;
            }
        }
        #endregion
    }
}

