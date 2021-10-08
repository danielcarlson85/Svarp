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

        public static void Läs(Code code, CodeRow codeRow)
        {
            var stringVariable = code.StringVariables.Find(v => v.VariableName == codeRow.RowVariableName);

            var inData = Console.ReadLine();
            if (stringVariable == null)
            {
                stringVariable = new StringVariable();
                stringVariable.VariableInputValue = inData;
                stringVariable.VariableName = codeRow.RowVariableName;
            }
            else
            {
                stringVariable.VariableInputValue = codeRow.RowVariableValue;
            }

            code.StringVariables.Add(stringVariable);
        }

        public static void Variable(Code code, CodeRow codeRow)
        {
            var stringVariable = code.StringVariables.Find(v => v.VariableName == codeRow.RowVariableName);

            if (stringVariable == null)
            {
                stringVariable = new StringVariable();
                stringVariable.VariableInputValue = codeRow.RowVariableValue;
                stringVariable.VariableName = codeRow.RowVariableName;
            }
            else
            {
                stringVariable.VariableInputValue = codeRow.RowVariableValue;
            }

            code.StringVariables.Add(stringVariable);
        }

    }
}
