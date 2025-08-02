using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace advancedSchoolManagementSystem
{
    internal class AuthService : IAuthService
    {
        private IStudentService studentService;
        public AuthService(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        #region GetPasswordStrength
        public PasswordStrength GetPasswordStrength(string password)
        {
            if (password.Length < 6)
                return PasswordStrength.Week;
            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;
            bool hasSympol = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                    hasUpper = true;
                if (char.IsLower(c))
                    hasLower = true;
                if (char.IsDigit(c))
                    hasDigit = true;
                else
                    hasSympol = true;
            }

            if (password.Length >= 7 && hasSympol && hasLower && hasUpper && hasDigit)
                return PasswordStrength.Strong;
            else if (hasLower && hasDigit)
                return PasswordStrength.Medium;

            return PasswordStrength.Week;
        }
        #endregion

        #region Register
        public void RegisterStudent(IStudentService studentService)
        {
            Console.Clear();
            ConsoleStyler.PrintInputPrompt("Enter Your Name (or b to go back): ");
            string name = Console.ReadLine().ToLower().Trim();
            if (InputHelper.IsBackOption(name))
                return;
            int id;
            ConsoleStyler.PrintInputPrompt("Enter Your ID (or b to go back): ");
            string input = Console.ReadLine();
            if (InputHelper.IsBackOption(input))
                return;
            while (!int.TryParse(input, out id))
            {
                ConsoleStyler.PrintWarning("Invalid ID! Please enter a number: ");
                bool convert = int.TryParse(Console.ReadLine(), out id);
                if (convert)
                    break;
            }

            if (studentService.IsIDTaken(id))
            {
                ConsoleStyler.PrintWarning("This ID is already taken.");
                Console.ReadKey();
                return;
            }

            ConsoleStyler.PrintInputPrompt("Enter Your Password (or b to go back): ");
            string password = Console.ReadLine();
            if (InputHelper.IsBackOption(password))
                return;
            PasswordStrength strength = GetPasswordStrength(password);
            if (strength == PasswordStrength.Strong)
                ConsoleStyler.PrintSuccess($"Password strength: {strength}");
            else if (strength == PasswordStrength.Medium)
                ConsoleStyler.PrintWarning($"Password strength: {strength}");
            else
                ConsoleStyler.PrintError($"Password strength: {strength}");

            ConsoleStyler.PrintInputPrompt("Confirm Your Password (or b to go back): ");
            string confirmPassword = Console.ReadLine();
            if (InputHelper.IsBackOption(confirmPassword))
                return;
            while (password != confirmPassword)
            {
                ConsoleStyler.PrintWarning("Passwords do not match. Please try again.");

                ConsoleStyler.PrintInputPrompt("Enter Your Password (or b to go back): ");
                password = Console.ReadLine();
                if (InputHelper.IsBackOption(password))
                    return;
                strength = GetPasswordStrength(password);
                if (strength == PasswordStrength.Strong)
                    ConsoleStyler.PrintSuccess($"Password strength: {strength}");
                else if (strength == PasswordStrength.Medium)
                    ConsoleStyler.PrintWarning($"Password strength: {strength}");
                else
                    ConsoleStyler.PrintError($"Password strength: {strength}");


                ConsoleStyler.PrintInputPrompt("Confirm Your Password (or b to go back): ");
                confirmPassword = Console.ReadLine();
                if (InputHelper.IsBackOption(confirmPassword))
                    return;
            }

            Student student = new Student()
            {
                ID = id,
                Name = name,
                Password = password
            };

            studentService.AddStudent(student);
            ConsoleStyler.PrintSuccess("Student registered successfully.");
            studentService.SaveStudentsToJsonFile("students.json");

            ConsoleStyler.WaitForKey();
            new UIApp(studentService, this, new CourseService(), student).StudentMenu(student);

        }
        #endregion

        #region Login
        public void LoginStudent(IStudentService studentService)
        {
            Console.Clear();

            ConsoleStyler.PrintInputPrompt("Enter Your ID: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                ConsoleStyler.PrintWarning("Invalid ID! Please enter a number: ");
            }

            ConsoleStyler.PrintInputPrompt("Enter Your Password: ");
            string password = Console.ReadLine();

            var student = studentService.GetStudentByID(id);
            if (student != null && student.Password == password)
            {
                ConsoleStyler.PrintSuccess($"Welcome, {student.Name}!");

                ConsoleStyler.WaitForKey("Press any key to continue...");

                new UIApp(studentService, this, new CourseService(), student).StudentMenu(student);
            }
            else
            {
                ConsoleStyler.PrintError("Invalid ID or Password.");
                ConsoleStyler.WaitForKey("Press any key to continue...");
            }
        }
        #endregion

        #region Exit
        public void Exit()
        {
            Console.Clear();
            ConsoleStyler.PrintTitle("Thanks for using the system!");
            ConsoleStyler.PrintMenuOption("Goodbye and have a great day.");

            studentService.SaveStudentsToJsonFile("students.json");

            Console.ReadKey();
            Environment.Exit(0);
        }
        #endregion
    }
}
