using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advancedSchoolManagementSystem
{
    internal class InputHelper : IInputHelper
    {
        #region IsBackOption
        public static bool IsBackOption(string input)
        {
            return input.ToLower().Trim() == "b";
        }
        #endregion
    }
}
