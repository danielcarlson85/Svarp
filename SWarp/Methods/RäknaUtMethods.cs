using Svarp;
using System;
using System.Linq;

namespace SWarp.Methods
{
    public static class RäknaUtMethods
    {
        public static void RäknaUt(ProgramCode code, ProgramCodeOnRow codeRow)
        {
            var variablesOnRow = Parser.GetInputVariablesName(codeRow.FullCodeOnRow, "{", "}");



            var stringVariables = (variablesOnRow.Select(item => code.StringVariables.Find(v => v.VariableName == item.VariableName))).ToList();


            if (codeRow.FullCodeOnRow.Contains("\'"))
            {
                RäknaUtSträng(code, codeRow);
            }
            else if (variablesOnRow.Count > 2)
            {
                RäknaUtAllaVariabler(code, codeRow);
            }
            else
            {
                RäknaUtVariabel(code, codeRow);
            }
        }


        internal static void RäknaUtSträng(ProgramCode code, ProgramCodeOnRow codeRow)
        {
            string number2 = string.Empty;

            if (codeRow.RowText != null)
            {
                var op = Parser.GetFunctionOperator(codeRow.RowText);
                codeRow.Operator = op;
                string number1 = codeRow.RowText.Split(op)[0];
                number2 = codeRow.RowText.Split(op)[1];

                var result = 0;

                switch (codeRow.Operator)
                {
                    case "+":

                        result = int.Parse(number1) + int.Parse(number2);
                        break;
                    case "-":
                        result = int.Parse(number1) - int.Parse(number2);
                        break;
                    case "*":
                        result = int.Parse(number1) * int.Parse(number2);
                        break;
                    case "/":
                        result = int.Parse(number1) / int.Parse(number2);
                        break;

                    default:
                        break;
                }

                Console.WriteLine(result);
            }
        }


        internal static void RäknaUtVariabel(ProgramCode code, ProgramCodeOnRow codeRow)
        {
            string number1 = string.Empty;
            string number2 = string.Empty;

            var variable = code.StringVariables.SingleOrDefault(v => v.VariableName == codeRow.RowVariables[0].VariableName);

            if (variable != null)
            {
                var op = Parser.GetFunctionOperator(variable.VariableValue);
                codeRow.Operator = op;
                number1 = variable.VariableValue.Split(op)[0];
                number2 = variable.VariableValue.Split(op)[1];
            }

            var result = 0;

            switch (codeRow.Operator)
            {
                case "+":
                    result = int.Parse(number1) + int.Parse(number2);
                    break;
                case "-":
                    result = int.Parse(number1) - int.Parse(number2);
                    break;
                case "*":
                    result = int.Parse(number1) * int.Parse(number2);
                    break;
                case "/":
                    result = int.Parse(number1) / int.Parse(number2);
                    break;

                default:
                    break;
            }

            code.StringVariables.Find(v => v.VariableName == codeRow.RowVariables[0].VariableName).VariableValue = result.ToString();
        }

        public static void RäknaUtAllaVariabler(ProgramCode programCode, ProgramCodeOnRow programCodeOnRow)
        {
            var variablesOnRow = Parser.GetInputVariablesName(programCodeOnRow.FullCodeOnRow, "{", "}");

            var stringVariables = (variablesOnRow.Select(item => programCode.StringVariables.Find(v => v.VariableName == item.VariableName))).ToList();

            var summa = stringVariables.Find(a => a.VariableName == variablesOnRow[0].VariableName).VariableValue;
            var number1 = stringVariables.Find(a => a.VariableName == variablesOnRow[1].VariableName).VariableValue;
            var number2 = stringVariables.Find(a => a.VariableName == variablesOnRow[2].VariableName).VariableValue;
            var foundoperator = stringVariables.Find(a => a.VariableName == variablesOnRow[3].VariableName).VariableValue;



            var result = 0;

            switch (foundoperator)
            {
                case "+":
                    result = int.Parse(number1) + int.Parse(number2);
                    break;
                case "-":
                    result = int.Parse(number1) - int.Parse(number2);
                    break;
                case "*":
                    result = int.Parse(number1) * int.Parse(number2);
                    break;
                case "/":
                    result = int.Parse(number1) / int.Parse(number2);
                    break;

                default:
                    break;
            }

            programCode.StringVariables.Find(v => v.VariableName == programCodeOnRow.RowVariables[0].VariableName).VariableValue = result.ToString();


            Console.WriteLine(result);
        }
    }
}
