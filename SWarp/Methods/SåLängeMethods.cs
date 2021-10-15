using Svarp;
using Svarp.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWarp.Methods
{
    class SåLängeMethods
    {
        public static void SåLänge(ProgramCode code, ProgramCodeOnRow codeRow)
        {
            var op = Parser.GetLoopOperator(codeRow.RowVariables[0].VariableName);
            codeRow.Operator = op;

            int number1 = int.Parse(codeRow.RowVariables[0].VariableName.Split(op)[0]);
            int number2 = int.Parse(codeRow.RowVariables[0].VariableName.Split(op)[1]);


            var savedVariables = Parser.GetInputVariablesName(codeRow.FullCodeOnRow, "{", "}");

            var foundVariables = (savedVariables.Select(item => code.StringVariables.Find(v => v.VariableName == item.VariableName))).ToList();



            switch (codeRow.Operator)
            {
                case "<":
                    while (number1 < number2)
                    {
                        Intepreter.Run(code, codeRow.Delegate);
                        number1++;
                    }
                    break;
                
                case ">":
                    while (number1 > number2)
                    {
                        Intepreter.Run(code, codeRow.Delegate);
                        number1--;
                    }

                    break;

                default:
                    break;
            }
        }
    }
}
