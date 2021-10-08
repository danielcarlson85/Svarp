using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Svarp
{
    class Program
    {
        static Code Code = new Code();

        static async Task Main(string[] args)
        {
            // För test kod i Svarp

            var svarpFile = "test.sv";

            // Öppna filen för att läsa in Svarp koden
            var file = await File.ReadAllLinesAsync(svarpFile);

            string[] parsedCode = ParseCode(file);

        }

        private static string[] ParseCode(string[] file)
        {
            foreach (var row in file)
            {
                if (string.IsNullOrEmpty(row))
                {
                    continue;
                }

                CodeRow codeRow = new CodeRow();

                var functionName = Helpers.GetFunctionName(row, "(", ")");
                codeRow.FunctionName = string.IsNullOrEmpty(functionName) ? "Variable" : functionName;

                codeRow.RowVariableName = Helpers.GetInputVariableName(row, "{", "}");
                codeRow.RowVariableValue = Helpers.GetFunctionInputText(row, "\"", "\"");

                codeRow.RowText = Helpers.GetFunctionInputText(row, "\"", "\"");

                Code.CodeRows.Add(codeRow);

            }
            Run(Code);


            return null;
        }

        private static void Run(Code code)
        {
            foreach (var codeRow in code.CodeRows)
            {
                switch (codeRow.FunctionName)
                {
                    case "Skriv":
                        Methods.Skriv(code, codeRow);
                        break;

                    case "Variable":

                        var stringVariable = code.StringVariables.Find(v => v.VariableName == codeRow.RowVariableName);

                        if (stringVariable == null)
                        {
                            stringVariable = new StringVariable();
                            stringVariable.VariableInputValue = codeRow.RowVariableValue;
                            stringVariable.VariableName = codeRow.RowVariableName;
                            code.StringVariables.Add(stringVariable);
                        }
                        else
                        {
                            stringVariable.VariableInputValue = codeRow.RowVariableValue;
                        }
                        break;

                    case "Läs":

                        var inData = Console.ReadLine();
                        stringVariable = code.StringVariables.Find(v => v.VariableName == codeRow.RowVariableName);

                        if (stringVariable == null)
                        {
                            stringVariable = new StringVariable();
                            stringVariable.VariableInputValue = inData;
                            stringVariable.VariableName = codeRow.RowVariableName;
                            code.StringVariables.Add(stringVariable);
                        }
                        else
                        {
                            stringVariable.VariableInputValue = codeRow.RowVariableValue;
                        }

                        break;
                }
            }
        }




        //private static string RunFunction(Code code)
        //{
        //    switch (function.FunctionName)
        //    {
        //        case "Skriv":

        //            var variable = function.StringVariable.Find(v => v.VariableName == function.VariableNameCache);

        //            if (variable != null)
        //            {
        //                if (string.IsNullOrEmpty(variable.VariableInputValue))
        //                {
        //                    Console.WriteLine(function.VariableInputValueCache);
        //                }

        //                Console.WriteLine(variable.VariableInputValue);
        //            }

        //            else
        //            {
        //                Console.WriteLine(function.VariableInputValueCache);
        //            }

        //            break;

        //        case "Variable":

        //            var stringVariable = function.StringVariable.Find(v => v.VariableName == function.VariableNameCache);

        //            if (stringVariable == null)
        //            {
        //                stringVariable = new StringVariable();
        //                stringVariable.VariableInputValue = function.VariableInputValueCache;
        //                stringVariable.VariableName = function.VariableNameCache;
        //                function.StringVariable.Add(stringVariable);
        //            }
        //            else
        //            {
        //                stringVariable.VariableInputValue = function.VariableInputValueCache;
        //            }

        //            break;

        //        case "Läs":

        //            var inData = Console.ReadLine();
        //            stringVariable = function.StringVariable.Find(v => v.VariableName == function.VariableNameCache);

        //            if (stringVariable == null)
        //            {
        //                stringVariable = new StringVariable();
        //                stringVariable.VariableInputValue = inData;
        //                stringVariable.VariableName = function.VariableNameCache;
        //                function.StringVariable.Add(stringVariable);
        //            }
        //            else
        //            {
        //                stringVariable.VariableInputValue = function.VariableInputValueCache;
        //            }

        //            break;
        //        default:
        //            break;
        //    }

        //    return null;
        //}


    }
}
