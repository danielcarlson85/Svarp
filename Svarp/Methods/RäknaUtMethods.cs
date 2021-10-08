using Svarp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWarp.Methods
{
    public static class RäknaUtMethods
    {
        internal static void RäknaUt(Code code, CodeRow codeRow)
        {
            var number1 = codeRow.RowText.Split(codeRow.Operator)[0];
            var number2 = codeRow.RowText.Split(codeRow.Operator)[1];

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

            var stringVariable = code.StringVariables.Find(v => v.VariableName == codeRow.RowVariableName);

            if (stringVariable == null)
            {
                stringVariable = new StringVariable();
                stringVariable.VariableInputValue = result.ToString();
                stringVariable.VariableName = codeRow.RowVariableName;
            }
            else
            {
                stringVariable.VariableInputValue = codeRow.RowVariableValue;
            }

            code.StringVariables.Add(stringVariable);
        }
    }
}
