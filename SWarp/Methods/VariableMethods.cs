namespace Svarp.Methods
{
    public static class VariableMethods
    {
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
