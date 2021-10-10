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
            var op = Parser.GetLoopOperator(codeRow.RowVariableName);
            codeRow.Operator = op;

            int number1 = int.Parse(codeRow.RowVariableName.Split(op)[0]);
            int number2 = int.Parse(codeRow.RowVariableName.Split(op)[1]);


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
