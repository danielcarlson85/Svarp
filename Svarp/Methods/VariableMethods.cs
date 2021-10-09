namespace Svarp.Methods
{
    public static class VariableMethods
    {
        public static void Variable(Code code, CodeRow codeRow)
        {
            var stringVariable = code.StringVariables.Find(v => v.VariableName == codeRow.RowVariableName);

            if (stringVariable == null)
            {
                stringVariable = new StringVariable();
                stringVariable.VariableValue = codeRow.RowText;
                stringVariable.VariableName = codeRow.RowVariableName;
            }
            else
            {
                stringVariable.VariableValue = codeRow.RowText;
            }

            code.StringVariables.Add(stringVariable);
        }
    }
}
