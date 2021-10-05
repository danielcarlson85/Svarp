using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Svarp
{
    class StringVariable
    {
        public string VariableName { get; set; }
        public string VariableInputValue { get; set; }
    }

    class Function
    {
        public List<StringVariable> StringVariable { get; set; } = new List<StringVariable>();
        public string VariableNameCache { get; set; }
        public string VariableInputValueCache { get; set; }

        public string FunctionName { get; set; }
    }

    class Program
    {
        private static Function function = new Function();


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


                var functionName = Helpers.GetFunctionName(row, "(", ")");
                function.FunctionName = string.IsNullOrEmpty(functionName) ? "Variable" : functionName;

                function.VariableNameCache = Helpers.GetInputVariableName(row, "{", "}");
                function.VariableInputValueCache = Helpers.GetFunctionInputText(row, "=\"", "\"");

                RunFunction(function);
            }
            return null;
        }


        private static string RunFunction(Function function)
        {
            switch (function.FunctionName)
            {
                case "Skriv":

                    var variable = function.StringVariable.Find(v => v.VariableName == function.VariableNameCache);

                    if (variable != null)
                    {
                        if (string.IsNullOrEmpty(variable.VariableInputValue))
                        {
                            Console.WriteLine(function.VariableInputValueCache);
                        }

                        Console.WriteLine(variable.VariableInputValue);
                    }

                    else
                    {
                        Console.WriteLine(function.VariableInputValueCache);
                    }
                    
                    break;

                case "Variable":

                    var stringVariable = function.StringVariable.Find(v => v.VariableName == function.VariableNameCache);

                    if (stringVariable == null)
                    {
                        stringVariable = new StringVariable();
                        stringVariable.VariableInputValue = function.VariableInputValueCache;
                        stringVariable.VariableName = function.VariableNameCache;
                        function.StringVariable.Add(stringVariable);
                    }
                    else
                    {
                        stringVariable.VariableInputValue = function.VariableInputValueCache;
                    }

                    break;

                case "Läs":

                    var inData = Console.ReadLine();
                    stringVariable = function.StringVariable.Find(v => v.VariableName == function.VariableNameCache);

                    if (stringVariable == null)
                    {
                        stringVariable = new StringVariable();
                        stringVariable.VariableInputValue = inData;
                        stringVariable.VariableName = function.VariableNameCache;
                        function.StringVariable.Add(stringVariable);
                    }
                    else
                    {
                        stringVariable.VariableInputValue = function.VariableInputValueCache;
                    }

                    break;
                default:
                    break;
            }

            return null;
        }


    }
}
