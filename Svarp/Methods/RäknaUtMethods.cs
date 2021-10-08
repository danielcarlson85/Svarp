using Svarp;
using System.Linq;

namespace SWarp.Methods
{
    public static class RäknaUtMethods
    {
        internal static void RäknaUt(Code code, CodeRow codeRow)
        {
            string number1 = string.Empty;
            string number2 = string.Empty;

            var variable = code.StringVariables.SingleOrDefault(v => v.VariableName == codeRow.RowVariableName);

            if (variable != null)
            {
                var op = Helpers.GetFunctionOperator(variable.VariableValue);
                codeRow.Operator = op;
                number1 = variable.VariableValue.Split(op)[0];
                number2 = variable.VariableValue.Split(op)[1];
            }
            else
            {
                number1 = codeRow.RowText.Split(codeRow.Operator)[0];
                number2 = codeRow.RowText.Split(codeRow.Operator)[1];
            }


            int result = 0;

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

            if (codeRow.RowText == string.Empty)
            {
                var stringVariable = code.StringVariables.Find(v => v.VariableName == codeRow.RowVariableName);

                if (stringVariable == null)
                {
                    stringVariable = new StringVariable();
                    stringVariable.VariableValue = result.ToString();
                    stringVariable.VariableName = codeRow.RowVariableName;
                    code.StringVariables.Add(stringVariable);
                }
                else
                {
                    stringVariable.VariableValue = result.ToString();
                }
            }
        }
    }
}
