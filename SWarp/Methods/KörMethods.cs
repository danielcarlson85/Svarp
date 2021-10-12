using Svarp;

namespace SWarp.Methods
{
    public class KörMethods
    {
        public static void KörMetod(ProgramCode code, ProgramCodeOnRow codeRow)
        {
            var motod = code.Methods.Find(v => v.MenthodName == codeRow.RowVariables[0].VariableName);

            foreach (var item in motod.CodeRows)
            {
                Intepreter.Run(code, item);
            }
        }
    }
}
