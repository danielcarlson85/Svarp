using Svarp;

namespace SWarp.Methods
{
    public class KörMethods
    {
        public static void KörMetod(ProgramCode code, ProgramCodeOnRow codeRow)
        {
            var motod = code.Methods.Find(v => v.MenthodName == codeRow.RowVariableName);

            foreach (var item in motod.CodeRows)
            {
                Intepreter.Run(code, item);
            }

            //var inData = Console.ReadLine();

            //if (rowVariable != null)
            //{
            //    rowVariable.VariableValue = codeRow.RowVariableValue;
            //}
            //else
            //{
            //    rowVariable = new StringVariable
            //    {
            //        VariableValue = inData,
            //        VariableName = codeRow.RowVariableName
            //    };
            //}

            //CheckIfVariableExistAndUpdate(code, rowVariable);
        }
    }
}
