
Advanced School Management System

This is a C# console-based application simulating a school management system. It allows students to register, log in, enroll in courses, remove courses, view their enrolled courses, and delete their accounts. The application also saves student data using a JSON file.


---

Overview

The project applies Object-Oriented Programming concepts and follows SOLID design principles. It uses a clean, modular architecture, separating responsibilities across interfaces and services. It also provides a friendly console UI using color-coded messages for better user experience.


---

📂 Class & Method Documentation

Program.cs

Main()
Entry point of the application. Initializes dependencies and calls ShowMainMenu().



---

Student.cs

Represents a student object.

ID: Unique identifier.

Name: Full name of the student.

Password: Login password.

enrolledCourses: A list storing the courses the student is enrolled in.



---

Course.cs

Represents a course object.

CourseID: Unique course identifier.

CourseName: Name of the course.

CourseCredits: Number of credits for the course.



---

Interfaces & Implementations

IStudentService

Interface for student-related operations:

AddStudent(Student student)

EnrollingInCourses(int courseID, int studentID)

RemoveCourseFromStudent(int courseID, int studentID)

ConfirmRemoveCourse(int courseID, int studentID)

DeleteStudent(int studentID)

ConfirmDeleteStudent(int studentID)

IsIDTaken(int id)

DisplayStudentInfo(Student student)

GetStudentByID(int id)



---

StudentService.cs

Implements IStudentService:

Stores students in a list.

Handles student registration and deletion.

Manages course enrollment and removal.

Checks for duplicate student IDs.

Displays enrolled course info.

Uses try-catch blocks for error handling.



---

ICourseService

Interface for course-related operations:

ShowCourses()

GetCourseByID(int id)



---

CourseService.cs

Implements ICourseService:

Stores a list of predefined courses.

Displays courses to the user.

Retrieves course by ID.



---

IAuthService

Handles authentication logic:

RegisterStudent(IStudentService)

LoginStudent(IStudentService)

Exit()

GetPasswordStrength(string)



---

AuthService.cs

Implements IAuthService:

Registers new students.

Validates password strength and matching.

Prevents duplicate IDs.

Logs users in and navigates them to their menus.

Provides exit functionality.



---

IUIApp

Interface for UI display:

ShowMainMenu()

StudentMenu(Student student)



---

UIApp.cs

Implements IUIApp:

Displays main and student menus.

Handles user input and navigation.

Provides back (b) option on key prompts.

Delegates logic to service classes.



---

IConsoleStyler

Interface defining formatting methods:

PrintSuccess(string)

PrintError(string)

PrintWarning(string)

PrintInputPrompt(string)

PrintTitle(string)

PrintMenuOption(object)

WaitForKey(string message)



---

ConsoleStyler.cs

Implements IConsoleStyler:

Displays messages with appropriate colors.

Green for success

Red for errors

Yellow for warnings

Cyan for inputs


Ensures consistent styling throughout the app.



---

IInputHelper

IsBackOption(string input)
Checks if the user typed 'b' to go back.



---

InputHelper.cs

Utility class that simplifies back-option checks across the app.


---

💾 Data Persistence with JSON

Student data, including course enrollments, is saved in a students.json file.

After every action (add, delete, enroll, remove), the data is saved.

On app startup, the file is read to restore previous data.



---

✅ SOLID Principles

SRP (Single Responsibility Principle): Each class handles one responsibility.

OCP (Open/Closed Principle): Interfaces allow extensions without modifying existing logic.

LSP (Liskov Substitution Principle): Design ensures correct interface usage.

ISP (Interface Segregation Principle): Interfaces are specific and separated.
DIP (Dependency Inversion Principle): High-level modules depend on abstractions.

---

📝 Usage Notes

All prompts accept 'b' to return to the previous menu.

Color-coded output improves readability.

Errors and exceptions are gracefully handled.

The UI is kept clean, spaced, and well-organized.