﻿using System;

namespace Svarp.Methods
{
    class LäsMethods
    {
        public static void Läs(Code code, CodeRow codeRow)
        {
            Console.Write(codeRow.RowText);
            var rowVariable = code.StringVariables.Find(v => v.VariableName == codeRow.RowVariableName);

            var inData = Console.ReadLine();

            if (rowVariable != null)
            {
                rowVariable.VariableValue = codeRow.RowVariableValue;
            }
            else
            {
                rowVariable = new StringVariable
                {
                    VariableValue = inData,
                    VariableName = codeRow.RowVariableName
                };
            }

            code.StringVariables.Add(rowVariable);
        }
    }
}
