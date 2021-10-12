using Svarp;

namespace SWarp.Methods
{
    class OmMethods
    {
        public static void Om(ProgramCode code, ProgramCodeOnRow codeRow)
        {
            string variable1 = codeRow.OmValue[0];
            string variable2 = codeRow.OmValue[1];

            var variable1Value = code.StringVariables.Find(v => v.VariableName == variable1);
            var variable2Value = code.StringVariables.Find(v => v.VariableName == variable2);

            if (variable2Value == null)
            {
                variable2Value = new Variables() { VariableValue = variable2 };
            }

            switch (codeRow.OmOperator)
            {
                case "==":
                    if (variable1Value.VariableValue == variable2Value.VariableValue)
                    {
                        Intepreter.Run(code, codeRow.Delegate);
                    }
                    break;

                case "!=":
                    if (variable1Value.VariableValue != variable2Value.VariableValue)
                    {
                        Intepreter.Run(code, codeRow.Delegate);
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
