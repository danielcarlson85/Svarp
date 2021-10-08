//namespace Svarp
//{
//    class Lexer
//    {
//        public static Code LexCode(Code code, string rowCode)
//        {
//            CodeRow codeRow = new CodeRow();

//            var functionName = Helpers.GetFunctionName(rowCode, "(", ")");
//            codeRow.Function.FunctionName = string.IsNullOrEmpty(functionName) ? "Variable" : functionName;

//            codeRow.StringVariables = Helpers.GetVariableNames(rowCode);



//            codeRow.RowText = Helpers.GetFunctionInputText(rowCode, "\"", "\"");
//            code.CodeRows.Add(codeRow);

//            return code;
//        }
//    }
//}



//foreach (var item in codeRow.StringVariables)
//{
//    foreach (var variable in code.StringVariables)
//    {
//        if (variable.VariableName == item.VariableName)
//        {
//            inData = Console.ReadLine();

//            variable.VariableInputValue = inData;
//            variable.VariableName = item.VariableName;
//            code.StringVariables.Add(variable);
//        }
//        else
//        {
//            inData = Console.ReadLine();

//            variable.VariableInputValue = inData;
//            variable.VariableName = item.VariableName;
//            code.StringVariables.Add(variable);

//        }
//    }
//}
