namespace Svarp
{
    class Lexer
    {
        public static Code LexCode(Code code, string row)
        {
            CodeRow codeRow = new();

            var functionName = Parser.GetFunctionName(row, "(", ")");
            codeRow.FunctionName = string.IsNullOrEmpty(functionName) ? "Variable" : functionName;

            codeRow.RowVariableName = Parser.GetInputVariableName(row, "{", "}");
            codeRow.RowText = Parser.GetFunctionInputText(row, "\"", "\"");
            codeRow.Operator = Parser.GetFunctionOperator(row);
            code.CodeRows.Add(codeRow);

            return code;
        }
    }
}
