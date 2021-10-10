using SWarp.Models;
using System.Collections.Generic;

namespace Svarp
{
    class Lexer
    {
        public static ProgramCode LexCode(ProgramCode code, List<string> file)
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

        private static ProgramCode GetMethods(ProgramCode code, List<string> file)
        {
            bool isMetod = false;

            ProgramMethods method = new();

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


        private static ProgramCodeOnRow GetMethodValues(string code)
        {
            if (code == string.Empty)
            {
                return new();
            }

            ProgramCodeOnRow codeRow = new();

            var functionName = Parser.GetFunctionName(code, "(", ")");
            codeRow.MethodName = string.IsNullOrEmpty(functionName) ? "Variabel" : functionName;

            codeRow.OmValue = Parser.GetOmValueFromRow(code, "<", ">");
            
            var stringd = Parser.GetOmInputFromRow(code, "<", ">");
            codeRow.OmOperator = Parser.GetOmOperator(stringd);



            var deledgateCode = Parser.GetDelegateFromRow(code, "@", "@");
            if (deledgateCode != string.Empty)
            {
                codeRow.Delegate = GetMethodValues(deledgateCode);
            }
            else
            {
                codeRow.Delegate = new();
            }

            codeRow.RowVariableName = Parser.GetInputVariableName(code, "{", "}");
            codeRow.RowText = Parser.GetFunctionInputText(code, "\"", "\"");
            codeRow.Operator = Parser.GetFunctionOperator(code);

            return codeRow;
        }
    }
}
