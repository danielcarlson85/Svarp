namespace Svarp
{
    class Lexer
    {
        public static Code LexCode(Code code, string row)
        {
            CodeRow codeRow = new CodeRow();

            var functionName = Helpers.GetFunctionName(row, "(", ")");
            codeRow.FunctionName = string.IsNullOrEmpty(functionName) ? "Variable" : functionName;

            codeRow.RowVariableName = Helpers.GetInputVariableName(row, "{", "}");
            codeRow.RowText = Helpers.GetFunctionInputText(row, "\"", "\"");
            code.CodeRows.Add(codeRow);

            return code;
        }
    }
}
