using System.Linq;
using Swarp;
using Swarp.Common.Models;

namespace SWarp.Methods
{
    public class KörMethods
    {
        public static void KörMetod(ProgramCode code, ProgramCodeOnRow codeRow)
        {

            var metodNameOnRow = codeRow.FullCodeOnRow.Split(":")[1];

            var moetodNamn = code.Methods.SingleOrDefault(v => v.MenthodName == metodNameOnRow);

            foreach (var item in moetodNamn.CodeRows)
            {
                Intepreter.Run(code, item);
            }
        }
    }
}
