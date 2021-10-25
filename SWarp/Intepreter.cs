using System;
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
            try
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

                    case MethodConstants.Skriv:
                        SkrivMethods.SkrivUt(programCode, programCodeOnRow);
                        break;

                    case MethodConstants.Variabel:
                        VariableMethods.Variabel(programCode, programCodeOnRow);
                        break;

                    case MethodConstants.Läs:
                        LäsMethods.LäsIn(programCode, programCodeOnRow);
                        break;

                    case MethodConstants.Räkna:
                        RäknaUtMethods.Räkna(programCode, programCodeOnRow);
                        break;
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"An exeption happend and is on line: {programCodeOnRow.CodeRowNumber}  in your SWarp code \n{ ex.StackTrace }");
            }
        }
    }
}
