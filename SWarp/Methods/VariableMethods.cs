using System;
using Swarp.Common.Models;

namespace Swarp.Methods
{
    public static class VariableMethods
    {
        public static void Variabel(ProgramCode code, ProgramCodeOnRow codeRow)
        {
            var hasValue = codeRow.RowVariables.Count != 0 ? true : false;
            if (hasValue)
            {
                var rowVariable = code.StringVariables.Find(v => v.VariableName == codeRow.RowVariables[0].VariableName);

                if (rowVariable != null)
                {
                    rowVariable.VariableValue = codeRow.RowVariableValue;
                }
                else
                {
                    rowVariable = new Variables
                    {
                        VariableValue = codeRow.RowText,
                        VariableName = codeRow.RowVariables[0].VariableName
                    };
                }

                CheckIfVariableExistAndUpdate(code, rowVariable);
            }
            else
            {
                Console.WriteLine("\nNo input variable declared");
            }
        }


        /*
        public static void Variabel(ProgramCode code, ProgramCodeOnRow codeRow)
        {

            var variablesOnRow = Parser.GetInputVariablesName(codeRow.FullCodeOnRow);

            var stringVariable = code.StringVariables.Find(v => v.VariableName == variablesOnRow[0].VariableName);

            if (stringVariable == null)
            {
                stringVariable = new Variables
                {
                    VariableValue = codeRow.RowText,
                    VariableName = variablesOnRow[0].VariableName
                };
            }
            else
            {
                stringVariable.VariableValue = codeRow.RowText;
            }

            CheckIfVariableExistAndUpdate(code, stringVariable);
        }
        */
        private static void CheckIfVariableExistAndUpdate(ProgramCode code, Variables stringVariable)
        {
            var variebleExist = code.StringVariables.Find(v => v.VariableName == stringVariable.VariableName);

            if (variebleExist == null)
            {
                code.StringVariables.Add(stringVariable);
            }
            else
            {
                code.StringVariables.Find(v => v.VariableName == stringVariable.VariableName).VariableValue = stringVariable.VariableValue;
            }
        }
    }
}
