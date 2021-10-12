using System;

namespace Svarp.Methods
{
    public class SkrivMethods
    {
        public static void SkrivUt(ProgramCode code, ProgramCodeOnRow codeRow)
        {
            Console.WriteLine(codeRow.RowText);
        }

        internal static void SkrivUtVariabel(ProgramCode code, ProgramCodeOnRow codeRow)
        {
            var variables = Parser.GetInputVariablesName(codeRow.FullCodeOnRow, "{", "}");

            var variable = code.StringVariables.Find(v => v.VariableName == codeRow.RowVariables[0].VariableName);

            if (variable != null)
            {
                Console.WriteLine(variable.VariableValue);
            }
        }

        internal static void SkrivUtVariabelOchText(ProgramCode code, ProgramCodeOnRow codeRow)
        {
            var variable = code.StringVariables.Find(v => v.VariableName == codeRow.RowVariables[0].VariableName);

            if (variable is not null)
            {
                Console.WriteLine(codeRow.RowText + variable.VariableValue);
            }
        }
    }
}