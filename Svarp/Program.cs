using System;
using System.IO;
using System.Threading.Tasks;

namespace Svarp
{
    class StringVariable
    {
        public string VariableName { get; set; }
        public string VariableValue { get; set; }
    }



    class Program
    {
        private static string functionCachedName;
        private static string parameterCachedName;

        private static StringVariable Variable = new StringVariable();


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
                functionCachedName = GetFunctionName(row, "(", ")");
                parameterCachedName = GetFunctionParameters(row, "\"", "\"");
                Variable.VariableName= GetInputVariableName(row, "{", "}");

                RunFunctions(functionCachedName, parameterCachedName, Variable);
            }
            return null;
        }



        public static string GetInputVariableName(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }

            return "";
        }

        public static string GetFunctionName(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }

            return "";
        }

        private static string RunFunctions(string function, string parameters, StringVariable variable)
        {
            switch (function)
            {
                case "Skriv":
                    Console.WriteLine(parameters + variable.VariableValue);
                    break;

                case "Läs":
                    Console.WriteLine(parameters);
                    var inData = Console.ReadLine();
                    variable.VariableValue = inData;
                    break;
                default:
                    break;
            }

            return null;
        }

        public static string GetFunction(string text, string stopAt = "-")
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    return text.Substring(0, charLocation);
                }
            }

            return String.Empty;
        }




        public static string GetFunctionParameters(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }

            return "";
        }
    }
}
