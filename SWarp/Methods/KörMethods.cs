using Svarp;

namespace SWarp.Methods
{
    public class KörMethods
    {
        public static void KörMetod(ProgramCode code, ProgramCodeOnRow codeRow)
        {

            var metodNameOnRow = codeRow.FullCodeOnRow.Split(":");


            var motod = code.Methods.Find(v => v.MenthodName == metodNameOnRow[1]);

            foreach (var item in motod.CodeRows)
            {
                Intepreter.Run(code, item);
            }
        }
    }
}
