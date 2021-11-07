using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Swarp.Common.Enums;
using Swarp.Common.Models;

namespace Swarp
{
    public static class Parser
    {
        public static List<Variables> GetInputVariablesName(string codeOnRow)
        {
            var variables = new List<Variables>();

            MatchCollection mcol = Regex.Matches(codeOnRow, @"{\b\S+?\b}");

            int order = 0;
            foreach (Match m in mcol)
            {
                var variable = m.ToString();
                variable = variable.Replace("{", string.Empty);
                variable = variable.Replace("}", string.Empty);

                variables.Add(new Variables()
                {
                    VariableName = variable,
                    VariableType = int.TryParse(variable, out _) ? VariableType.Int : VariableType.String,
                    Order = order

                });

                order++;
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

        public static string GetFunctionName(string codeRow, string strStart, string strEnd)
        {
            if (codeRow.Contains('(') && codeRow.Contains(')'))
            {
                int Start, End;
                Start = codeRow.IndexOf(strStart, 0) + strStart.Length;
                End = codeRow.IndexOf(strEnd, Start);
                return codeRow.Substring(Start, End - Start);
            }

            return "";
        }

        public static string GetDelegateFromRow(string codeRow, string strStart, string strEnd)
        {
            if (codeRow.Contains(strStart) && codeRow.Contains(strEnd))
            {
                int Start, End;
                Start = codeRow.IndexOf(strStart, 0) + strStart.Length;
                End = codeRow.IndexOf(strEnd, Start);
                return codeRow.Substring(Start, End - Start);
            }

            return "";
        }

        public static string GetOmInputFromRow(string codeRow, string strStart, string strEnd)
        {
            if (codeRow.Contains(strStart) && codeRow.Contains(strEnd))
            {
                int Start, End;
                Start = codeRow.IndexOf(strStart, 0) + strStart.Length;
                End = codeRow.IndexOf(strEnd, Start);
                return codeRow.Substring(Start, End - Start);
            }

            return string.Empty;
        }

        public static List<string> GetOmValueFromRow(string codeRow, string strStart, string strEnd)
        {
            if (codeRow.Contains(strStart) && codeRow.Contains(strEnd))
            {
                int Start, End;
                Start = codeRow.IndexOf(strStart, 0) + strStart.Length;
                End = codeRow.IndexOf(strEnd, Start);
                codeRow = codeRow.Substring(Start, End - Start);
            }


            List<string> omValues = new();
            var omOperator = GetOmOperator(codeRow);
            if (omOperator != string.Empty)
            {
                omValues.Add(codeRow.Split(omOperator)[0]);
                omValues.Add(codeRow.Split(omOperator)[1]);


                return omValues;
            }

            return new List<string>();
        }


        public static string GetFunctionInputText(string codeRow, string strStart, string strEnd)
        {
            if (codeRow == string.Empty)
            {
                return string.Empty;
            }

            if (codeRow.Contains(strStart) && codeRow.Contains(strEnd))
            {
                int Start, End;
                Start = codeRow.IndexOf(strStart, 0) + strStart.Length;
                End = codeRow.IndexOf(strEnd, Start);
                return codeRow.Substring(Start, End - Start);
            }

            return "";
        }
    }
}
