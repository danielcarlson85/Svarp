using Svarp;
using System;
using System.Linq;

namespace SWarp.Methods
{
    public static class RäknaUtMethods
    {
        internal static void RäknaUt(Code code, CodeRow codeRow)
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


        internal static void RäknaUtVariable(Code code, CodeRow codeRow)
        {
            string number1 = string.Empty;
            string number2 = string.Empty;

            var variable = code.StringVariables.SingleOrDefault(v => v.VariableName == codeRow.RowVariableName);

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

            code.StringVariables.Find(v => v.VariableName == codeRow.RowVariableName).VariableValue = result.ToString();
        }
    }
}
