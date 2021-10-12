using Svarp;
using Svarp.Methods;
using SWarp.Methods;

namespace SWarp
{
    class Intepreter
    {
        public static void Run(ProgramCode programCode, ProgramCodeOnRow programCodeOnRow)
        {
            switch (programCodeOnRow.MethodName)
            {
                case "Om":
                    OmMethods.Om(programCode, programCodeOnRow);
                    break;

                case "KörMetod":
                    KörMethods.KörMetod(programCode, programCodeOnRow);
                    break;

                case "SåLänge":
                    SåLängeMethods.SåLänge(programCode, programCodeOnRow);
                    break;

                case "SkrivUt":
                    SkrivMethods.SkrivUt(programCode, programCodeOnRow);
                    break;
                case "SkrivUtVariabel":
                    SkrivMethods.SkrivUtVariabel(programCode, programCodeOnRow);
                    break;

                case "SkrivUtVariabelOchText":
                    SkrivMethods.SkrivUtVariabelOchText(programCode, programCodeOnRow);
                    break;

                case "Variabel":
                    VariableMethods.Variabel(programCode, programCodeOnRow);
                    break;

                case "LäsIn":
                    LäsMethods.LäsIn(programCode, programCodeOnRow);
                    break;
                case "LäsInklTitel":
                    LäsMethods.LäsInklTitel(programCode, programCodeOnRow);
                    break;

                case "RäknaUtVariabel":
                    RäknaUtMethods.RäknaUtVariabel(programCode, programCodeOnRow);
                    break;

                case "RäknaUt":
                    RäknaUtMethods.RäknaUt(programCode, programCodeOnRow);
                    break;
            }
        }
    }
}
