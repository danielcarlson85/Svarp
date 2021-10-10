using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svarp.Methods
{
    public class SkrivMethods
    {
        public static void SkrivUt(ProgramCode code, ProgramCodeOnRow codeRow)
        {
            Console.WriteLine(codeRow.RowText);
        }

        internal static void SkrivUtVariabel(ProgramCode code, ProgramCodeOnRow codeRow)
        {
            var variable = code.StringVariables.Find(v => v.VariableName == codeRow.RowVariableName);

            if (variable != null)
            {
                Console.WriteLine(variable.VariableValue);
            }
        }

        internal static void SkrivUtVariabelOchText(ProgramCode code, ProgramCodeOnRow codeRow)
        {
            var variable = code.StringVariables.Find(v => v.VariableName == codeRow.RowVariableName);

            if (variable is not null)
            {
                Console.WriteLine(codeRow.RowText + variable.VariableValue);
            }
        }
    }
}