using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Svarp
{
    static class Parser
    {
        public static List<Variables> GetInputVariablesName(string strSource, string strStart, string strEnd)
        {
            var variables = new List<Variables>();

            MatchCollection mcol = Regex.Matches(strSource, @"{\b\S+?\b}");
            foreach (Match m in mcol)
            {
                var variable = m.ToString();
                variable = variable.Replace("{", string.Empty);
                variable = variable.Replace("}", string.Empty);

                variables.Add(new Variables()
                {
                    VariableName = variable,
                    VariableType = int.TryParse(variable, out _) ? VariableType.Int : VariableType.String
                });
            }

            return variables;
        }

        internal static string GetLoopOperator(string row)
        {
            List<string> op = new()
            {
                "<",
                ">",
                "==",
                "<=",
                ">=",
                "!="
            };

            foreach (var item in op.Where(item => row.Contains(item)))
                return item;

            return string.Empty;
        }

        internal static string GetOmOperator(string row)
        {
            List<string> op = new()
            {
                "<",
                ">",
                "==",
                "!=",
                "<=",
                ">="
            };

            foreach (var item in op.Where(item => row.Contains(item)))
                return item;

            return string.Empty;
        }

        internal static string GetFunctionOperator(string row)
        {
            List<string> op = new()
            {
                "*",
                "+",
                "-",
                "/"
            };

            foreach (var item in op.Where(item => row.Contains(item)))
                return item;

            return string.Empty;
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

        public static string GetDelegateFromRow(string strSource, string strStart, string strEnd)
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

        public static string GetOmInputFromRow(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }

            return string.Empty;
        }

        public static List<string> GetOmValueFromRow(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                strSource = strSource.Substring(Start, End - Start);
            }


            List<string> omValues = new();
            var omOperator = GetOmOperator(strSource);
            if (omOperator != string.Empty)
            {
                omValues.Add(strSource.Split(omOperator)[0]);
                omValues.Add(strSource.Split(omOperator)[1]);


                return omValues;
            }

            return new List<string>();
        }


        public static string GetFunctionInputText(string strSource, string strStart, string strEnd)
        {
            if (strSource == string.Empty)
            {
                return string.Empty;
            }

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
