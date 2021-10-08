using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svarp
{
    static class Methods
    {
        public static void Skriv(Code code, CodeRow codeRow)
        {
            var variable = code.StringVariables.Find(v => v.VariableName == codeRow.RowVariableName);

            if (variable != null)
            {
                if (string.IsNullOrEmpty(variable.VariableInputValue))
                {
                    Console.WriteLine(codeRow.RowText);
                }

                Console.WriteLine(variable.VariableInputValue);
            }

            else
            {
                Console.WriteLine(codeRow.RowText);
            }
        }
    }
}
