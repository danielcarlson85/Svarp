using SWarp.Models;
using System.Collections.Generic;

namespace Svarp
{
    class Lexer
    {
        public static Code LexCode(Code code, List<string> file)
        {
            code = GetMethods(code, file);

            foreach (var row in file)
            {
                if (string.IsNullOrEmpty(row)) continue;
                if (row.StartsWith("--")) continue;
                if (row.StartsWith("Metod")) continue;
                if (row.StartsWith('\t')) continue;


                var codeRow = GetMethodValues(row);
                code.CodeRows.Add(codeRow);
            }

            return code;
        }

        private static Code GetMethods(Code code, List<string> file)
        {
            bool isMetod = false;

            Method method = new();

            foreach (var item in file)
            {
                if (item.StartsWith("MetodStart"))
                {
                    isMetod = true;
                    method = new();
                    method.MenthodName = item.Split(":")[1];
                }

                if (item.StartsWith("MetodStop"))
                {
                    isMetod = false;
                    code.Methods.Add(method);
                }

                if (isMetod)
                {
                    if (!item.StartsWith("MetodStart"))
                    {
                        var codeRow = GetMethodValues(item);
                        method.CodeRows.Add(codeRow);
                    }
                }
            }

            return code;
        }


        private static CodeRow GetMethodValues(string delegateCode)
        {
            if (delegateCode == string.Empty)
            {
                return new();
            }

            CodeRow codeRow = new();

            var functionName = Parser.GetFunctionName(delegateCode, "(", ")");
            codeRow.MethodName = string.IsNullOrEmpty(functionName) ? "Variabel" : functionName;

            var deledgateCode = Parser.GetDelegateFromRow(delegateCode, "@", "@");
            codeRow.Delegate = GetMethodValues(deledgateCode);

            codeRow.RowVariableName = Parser.GetInputVariableName(delegateCode, "{", "}");
            codeRow.RowText = Parser.GetFunctionInputText(delegateCode, "\"", "\"");
            codeRow.Operator = Parser.GetFunctionOperator(delegateCode);

            return codeRow;
        }
    }
}
