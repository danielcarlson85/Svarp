namespace Svarp.Methods
{
    public static class VariableMethods
    {
        public static void Variabel(Code code, CodeRow codeRow)
        {
            var stringVariable = code.StringVariables.Find(v => v.VariableName == codeRow.RowVariableName);

            if (stringVariable == null)
            {
                stringVariable = new StringVariable
                {
                    VariableValue = codeRow.RowText,
                    VariableName = codeRow.RowVariableName
                };
            }
            else
            {
                stringVariable.VariableValue = codeRow.RowText;
            }

            CheckIfVariableExistAndUpdate(code, stringVariable);
        }

        private static void CheckIfVariableExistAndUpdate(Code code, StringVariable stringVariable)
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
