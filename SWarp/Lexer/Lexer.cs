using SWarp.Models;
using System;
using System.Collections.Generic;

namespace Svarp
{
    class Lexer
    {
        static int codeRowNumber = 0;

        public static ProgramCode LexCode(ProgramCode code, List<string> file)
        {
            code = GetMethods(code, file);

            try
            {

                foreach (var row in file)
                {
                    codeRowNumber++;
                    if (string.IsNullOrEmpty(row)) continue;
                    if (row.StartsWith("--")) continue;
                    if (row.StartsWith("Metod")) continue;
                    if (row.StartsWith('\t')) continue;

                    var codeRow = GetMethodValues(row);
                    code.StringVariables = Parser.GetInputVariablesName(row);

                    codeRow.CodeRowNumber = codeRowNumber;

                    code.CodeRows.Add(codeRow);
                }

                return code;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldnt Lex and Parse a line in your SWarp code,  Exeption is on line: {codeRowNumber}  in your SWarp code \n { ex.StackTrace }");
            }
            
        }

        private static ProgramCode GetMethods(ProgramCode code, List<string> file)
        {
            bool isMetod = false;

            ProgramMethods method = new();

            foreach (var item in file)
            {
                if (item.StartsWith("(MetodStart)"))
                {
                    isMetod = true;
                    method = new();
                    method.MenthodName = item.Split(":")[1];
                }

                if (item.StartsWith("(MetodSlut)"))
                {
                    isMetod = false;
                    code.Methods.Add(method);
                }

                if (isMetod)
                {
                    if (!item.StartsWith("(MetodStart)"))
                    {
                        var codeRow = GetMethodValues(item);
                        method.CodeRows.Add(codeRow);
                    }
                }
            }

            return code;
        }

        private static ProgramCode GetOmMethods(ProgramCode code, List<string> file)
        {
            bool isMetod = false;

            ProgramMethods method = new();

            foreach (var item in file)
            {
                if (item.StartsWith("(Om)"))
                {
                    isMetod = true;
                    method = new();
                    method.MenthodName = item.Split(":")[1];
                }

                if (item.StartsWith("(OmSlut)"))
                {
                    isMetod = false;
                    code.Methods.Add(method);
                }

                if (isMetod)
                {
                    if (!item.StartsWith("(MetodStart)"))
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
            codeRow.FullCodeOnRow = code;
            var deledgateCode = Parser.GetDelegateFromRow(code, "@", "@");
            if (deledgateCode != string.Empty)
            {
                codeRow.Delegate = GetMethodValues(deledgateCode);
            }
            else
            {
                codeRow.Delegate = new();
            }

            codeRow.RowVariables = Parser.GetInputVariablesName(code);
            codeRow.RowText = Parser.GetFunctionInputText(code, "\'", "\'");
            codeRow.Operator = Parser.GetFunctionOperator(code);

            return codeRow;
        }
    }
}
