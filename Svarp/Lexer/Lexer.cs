using System.Collections.Generic;

namespace Svarp
{
    class Lexer
    {
        public static Code LexCode(Code code, List<string> file)
        {
            foreach (var row in file)
            {
                if (string.IsNullOrEmpty(row)) continue;
                if (row.StartsWith("--")) continue;

                CodeRow codeRow = new();
                var functionName = Parser.GetFunctionName(row, "(", ")");
                codeRow.FunctionName = string.IsNullOrEmpty(functionName) ? "Variabel" : functionName;

                codeRow.RowVariableName = Parser.GetInputVariableName(row, "{", "}");
                codeRow.RowText = Parser.GetFunctionInputText(row, "\"", "\"");
                codeRow.Operator = Parser.GetFunctionOperator(row);

                var delegateCode = Parser.GetDelegateFromRow(row, "@", "@");
                codeRow.Delegate = GetDelegate(delegateCode);

                code.CodeRows.Add(codeRow);
            }
            
            return code;
        }

        private static CodeRow GetDelegate(string delegateCode)
        {
            if (delegateCode == string.Empty)
            {
                return new();
            }

            CodeRow codeRow = new();

            var functionName = Parser.GetFunctionName(delegateCode, "(", ")");
            codeRow.FunctionName = string.IsNullOrEmpty(functionName) ? "Variabel" : functionName;

            codeRow.RowVariableName = Parser.GetInputVariableName(delegateCode, "{", "}");
            codeRow.RowText = Parser.GetFunctionInputText(delegateCode, "\"", "\"");
            codeRow.Operator = Parser.GetFunctionOperator(delegateCode);

            return codeRow;
        }
    }
}
