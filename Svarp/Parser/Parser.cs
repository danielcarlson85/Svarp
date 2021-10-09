﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Svarp
{
    static class Parser
    {
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

        internal static string GetLoopValues(string row)
        {
            List<string> op = new()
            {
                "<",
                ">",
                "==",
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
