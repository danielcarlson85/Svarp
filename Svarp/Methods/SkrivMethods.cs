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
            var variable = code.StringVariables.Find(v => v.VariableName == codeRow.RowVariableName);

            if (variable is not null)
            {
                if (string.IsNullOrEmpty(variable.VariableValue))
                {
                    Console.WriteLine(codeRow.RowText);
                }

                Console.WriteLine(codeRow.RowText + variable.VariableValue);
            }
            else
            {
                Console.WriteLine(codeRow.RowText);
            }
        }
    }
}