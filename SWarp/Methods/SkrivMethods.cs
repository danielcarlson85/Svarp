using System;
using System.Collections.Generic;
using System.Linq;

namespace Svarp.Methods
{
    public class SkrivMethods
    {
        public static void SkrivUt(ProgramCode code, ProgramCodeOnRow codeRow)
        {
            if (codeRow.FullCodeOnRow.Contains("{") && !codeRow.FullCodeOnRow.Contains('\''))
            {
                SkrivUtVariabel(code, codeRow);
            }
            else if (codeRow.FullCodeOnRow.Contains('\'') && codeRow.FullCodeOnRow.Contains('{'))
            {
                SkrivUtVariabelOchText(code, codeRow);
            }
            else
            {
                Console.WriteLine(codeRow.RowText);
            }
        }

        internal static void SkrivUtVariabel(ProgramCode code, ProgramCodeOnRow codeRow)
        {
            var savedVariables = Parser.GetInputVariablesName(codeRow.FullCodeOnRow);

            var foundVariables = (savedVariables.Select(item => code.StringVariables.Find(v => v.VariableName == item.VariableName))).ToList();

            if (foundVariables != null)
            {
                foreach (var variable in foundVariables)
                {
                    Console.WriteLine(variable.VariableValue);
                }
            }
        }

        internal static void SkrivUtVariabelOchText(ProgramCode code, ProgramCodeOnRow codeRow)
        {
            var savedVariables = Parser.GetInputVariablesName(codeRow.FullCodeOnRow);

            var foundVariables = (savedVariables.Select(item => code.StringVariables.Find(v => v.VariableName == item.VariableName))).ToList();

            if (foundVariables != null)
            {
                foreach (var variable in foundVariables)
                {
                    Console.WriteLine(codeRow.RowText + variable.VariableValue);
                }
            }
        }
    }
}
