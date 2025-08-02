using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace advancedSchoolManagementSystem
{
    internal interface IConsoleStyler
    {
        static abstract void PrintSuccess(string message);
        static abstract void PrintError(string message);
        static abstract void PrintWarning(string message);
        static abstract void PrintInputPrompt(string message);
        static abstract void PrintTitle(string title);
        static abstract void PrintMenuOption(object option);
        static abstract void WaitForKey(string message = "Press any key to continue...");
    }
}
