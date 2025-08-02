using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace advancedSchoolManagementSystem
{
    internal interface IAuthService
    {
        PasswordStrength GetPasswordStrength(string password);
        void RegisterStudent(IStudentService studentService);
        void LoginStudent(IStudentService studentService);
        void Exit();
    }
}
