using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svarp.Methods
{
    public class SkrivMethods
    {
        public static void Skriv(Code code, CodeRow codeRow)
        {
            Console.WriteLine(codeRow.RowText);
        }

        internal static void SkrivVariable(Code code, CodeRow codeRow)
        {
            var variable = code.StringVariables.Find(v => v.VariableName == codeRow.RowVariableName);

            if (variable != null) Console.WriteLine(variable.VariableValue);
        }
    }
}