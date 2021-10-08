using System;

namespace Svarp.Methods
{
    class LäsMethods
    {
        public static void Läs(Code code, CodeRow codeRow)
        {
            Console.Write(codeRow.RowText);
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
    }
}
