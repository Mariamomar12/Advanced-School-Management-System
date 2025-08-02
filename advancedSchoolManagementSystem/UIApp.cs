using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace advancedSchoolManagementSystem
{
    internal class UIApp : IUIApp
    {
        private IStudentService _studentService;
        private IAuthService _authService;
        private ICourseService _courseService;
        private Student _currentStudent;

        public UIApp(IStudentService studentService, IAuthService authService, ICourseService courseService, Student student)
        {
            _studentService = studentService;
            _authService = authService;
            _courseService = courseService;
            _currentStudent = student;
        }

        #region StudentMenu
        public void StudentMenu(Student student)
        {
            while (true)
            {
                Console.Clear();
                ConsoleStyler.PrintTitle($"Welcome, {student.Name}");
                Console.WriteLine();
                ConsoleStyler.PrintMenuOption("1. View My Courses");
                ConsoleStyler.PrintMenuOption("2. Enroll in Course");
                ConsoleStyler.PrintMenuOption("3. Remove a Course");
                ConsoleStyler.PrintMenuOption("4. Delete My Account");
                ConsoleStyler.PrintMenuOption("5. Logout");

                Console.WriteLine();
                ConsoleStyler.PrintInputPrompt("Enter your choice: ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    ConsoleStyler.PrintWarning("Invalid choice! Please entar a valid choice: ");
                }

                switch (choice)
                {
                    case 1:
                        _studentService.DisplayStudentInfo(student);
                        break;
                    case 2:
                        while (true)
                        {
                            _courseService.ShowCourses();

                            ConsoleStyler.PrintInputPrompt("Enter Course ID to enroll (or b to go back): ");
                            string input = Console.ReadLine();
                            if (InputHelper.IsBackOption(input))
                                break;
                            int enrollID;
                            if (int.TryParse(input, out enrollID))
                            {
                                bool success = _studentService.EnrollingInCourses(enrollID, student.ID);
                                ConsoleStyler.WaitForKey("Press any key to continue.");
                            }
                            else
                            {
                                ConsoleStyler.PrintWarning("Invalid input! Please enter a valid number: ");
                                ConsoleStyler.WaitForKey();
                            }
                        }
                        break;

                    case 3:
                        ConsoleStyler.PrintInputPrompt("Enter Course ID to remove (or b to go back): ");
                        string input2 = Console.ReadLine();
                        if (InputHelper.IsBackOption(input2))
                            break;
                        int removeID;
                        if (int.TryParse(input2, out removeID))
                            _studentService.ConfirmRemoveCourse(removeID, student.ID);

                        ConsoleStyler.WaitForKey("Press any key to continue.");
                        break;
                    case 4:
                        _studentService.ConfirmDeleteStudent(student.ID);
                        ConsoleStyler.WaitForKey("Press any key to return to main menu...");
                        return;
                    case 5:
                        return;
                }
            }
        }
        #endregion

        #region ShowMainMenu
        public void ShowMainMenu()
        {
            var studentService = new StudentService();
            var authService = new AuthService(studentService);
            var courseService = new CourseService();
            studentService.LoadStudentsFromJsonFile("students.json");

            while (true)
            {
                Console.Clear();
                ConsoleStyler.PrintTitle("Advanced School Management System");
                Console.WriteLine();
                ConsoleStyler.PrintMenuOption("1. Register");
                ConsoleStyler.PrintMenuOption("2. Login");
                ConsoleStyler.PrintMenuOption("3. Exit");

                Console.WriteLine();

                ConsoleStyler.PrintInputPrompt("Enter your choice: ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice)) continue;

                switch (choice)
                {
                    case 1:
                        authService.RegisterStudent(studentService);
                        break;
                    case 2:
                        authService.LoginStudent(studentService);
                        break;
                    case 3:
                        authService.Exit();
                        break;
                }
            }
        }
        #endregion
    }
}
