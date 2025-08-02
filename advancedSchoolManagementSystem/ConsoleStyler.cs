using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace advancedSchoolManagementSystem
{
    internal class ConsoleStyler : IConsoleStyler
    {
        #region PrintSuccess
        public static void PrintSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        #endregion

        #region PrintError
        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        #endregion

        #region PrintWarning
        public static void PrintWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        #endregion

        #region PrintInputPrompt
        public static void PrintInputPrompt(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(message);
            Console.ResetColor();
        }
        #endregion

        #region PrintTitle
        public static void PrintTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            string line = new string('═', title.Length + 10);
            Console.WriteLine($"╔{line}╗");
            Console.WriteLine($"║   {title.ToUpper()}       ║");
            Console.WriteLine($"╚{line}╝");
            Console.ResetColor();
        }
        #endregion

        #region PrintMenuOption
        public static void PrintMenuOption(object option)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(option);
            Console.ResetColor();
        }
        #endregion

        #region WaitForKey
        public static void WaitForKey(string message = "Press any key to continue...")
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\n" + message);
            Console.ResetColor();
            Console.ReadKey();
        }
        #endregion
    }
}
