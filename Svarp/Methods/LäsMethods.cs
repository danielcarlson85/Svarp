using System;

namespace Svarp.Methods
{
    class LäsMethods
    {
        public static void LäsIn(Code code, CodeRow codeRow)
        {
            var rowVariable = code.StringVariables.Find(v => v.VariableName == codeRow.RowVariableName);

            var inData = Console.ReadLine();

            if (rowVariable != null)
            {
                rowVariable.VariableValue = codeRow.RowVariableValue;
            }
            else
            {
                rowVariable = new StringVariable
                {
                    VariableValue = inData,
                    VariableName = codeRow.RowVariableName
                };
            }

            CheckIfVariableExistAndUpdate(code, rowVariable);
        }

        internal static void LäsInklTitel(Code code, CodeRow codeRow)
        {
            Console.Write(codeRow.RowText);
            var rowVariable = code.StringVariables.Find(v => v.VariableName == codeRow.RowVariableName);

            var inData = Console.ReadLine();

            if (rowVariable != null)
            {
                rowVariable.VariableValue = codeRow.RowVariableValue;
            }
            else
            {
                rowVariable = new StringVariable
                {
                    VariableValue = inData,
                    VariableName = codeRow.RowVariableName
                };
            }

            CheckIfVariableExistAndUpdate(code, rowVariable);
        }


        private static void CheckIfVariableExistAndUpdate(Code code, StringVariable rowVariable)
        {
            var variebleExist = code.StringVariables.Find(v => v.VariableName == rowVariable.VariableName);

            if (variebleExist == null)
            {
                code.StringVariables.Add(rowVariable);
            }
            else
            {
                code.StringVariables.Find(v => v.VariableName == rowVariable.VariableName).VariableValue = rowVariable.VariableValue;
            }
        }
    }
}
