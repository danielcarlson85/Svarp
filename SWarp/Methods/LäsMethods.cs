using System;

namespace Svarp.Methods
{
    class LäsMethods
    {
        public static void LäsIn(ProgramCode code, ProgramCodeOnRow codeRow)
        {
            var hasValue = codeRow.RowVariables.Count != 0 ? true : false;

            if (hasValue)
            {
                if (codeRow.FullCodeOnRow.Contains('\''))
                {
                    LäsInInklTitel(code, codeRow);
                }
                else
                {
                    LäsInText(code, codeRow);
                }
            }
            else
            {
                Console.WriteLine("\nNo input variable declared");
            }
        }

        private static void LäsInText(ProgramCode code, ProgramCodeOnRow codeRow)
        {
            var rowVariable = code.StringVariables.Find(v => v.VariableName == codeRow.RowVariables[0].VariableName);

            var inData = Console.ReadLine();

            if (rowVariable != null)
            {
                rowVariable.VariableValue = codeRow.RowVariableValue;
            }
            else
            {
                rowVariable = new Variables
                {
                    VariableValue = inData,
                    VariableName = codeRow.RowVariables[0].VariableName
                };
            }

            CheckIfVariableExistAndUpdate(code, rowVariable);
        }

        private static void LäsInInklTitel(ProgramCode code, ProgramCodeOnRow codeRow)
        {
            Console.Write(codeRow.RowText);

            var rowVariable = code.StringVariables.Find(v => v.VariableName == codeRow.RowVariables[0].VariableName);
            rowVariable.VariableValue = codeRow.RowVariableValue;

            var inData = Console.ReadLine();

            var newRowVariable = new Variables
            {
                VariableValue = inData,
                VariableName = codeRow.RowVariables[0].VariableName
            };

            CheckIfVariableExistAndUpdate(code, newRowVariable);

        }

        private static void CheckIfVariableExistAndUpdate(ProgramCode code, Variables rowVariable)
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
