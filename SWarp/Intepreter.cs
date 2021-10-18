using System.Diagnostics;
using Svarp;
using Svarp.Methods;
using SWarp.Constants;
using SWarp.Methods;

namespace SWarp
{
    class Intepreter
    {
        public static void Run(ProgramCode programCode, ProgramCodeOnRow programCodeOnRow)
        {
            Debug.WriteLine($"{programCodeOnRow.CodeRowNumber}        Running code on row: {programCodeOnRow.FullCodeOnRow} on line: {programCodeOnRow.CodeRowNumber}");

            switch (programCodeOnRow.MethodName)
            {
                case MethodConstants.Om:
                    OmMethods.Om(programCode, programCodeOnRow);
                    break;

                case MethodConstants.KörMetod:
                    KörMethods.KörMetod(programCode, programCodeOnRow);
                    break;

                case MethodConstants.SåLänge:
                    SåLängeMethods.SåLänge(programCode, programCodeOnRow);
                    break;

                case MethodConstants.SkrivUt:
                    SkrivMethods.SkrivUt(programCode, programCodeOnRow);
                    break;

                case MethodConstants.Variabel:
                    VariableMethods.Variabel(programCode, programCodeOnRow);
                    break;

                case MethodConstants.LäsIn:
                    LäsMethods.LäsIn(programCode, programCodeOnRow);
                    break;

                case MethodConstants.Räkna:
                    RäknaUtMethods.Räkna(programCode, programCodeOnRow);
                    break;
            }
        }
    }
}
