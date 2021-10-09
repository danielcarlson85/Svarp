using Svarp;
using Svarp.Methods;
using SWarp.Methods;

namespace SWarp
{
    class Intepreter
    {
        public static void Run(Code code, CodeRow codeRow)
        {
            switch (codeRow.FunctionName)
            {
                case "SåLänge":
                    SåLängeMethods.SåLänge(code, codeRow);
                    break;

                case "SkrivUt":
                    SkrivMethods.SkrivUt(code, codeRow);
                    break;
                case "SkrivUtVariabel":
                    SkrivMethods.SkrivUtVariabel(code, codeRow);
                    break;

                case "SkrivUtVariabelOchText":
                    SkrivMethods.SkrivUtVariabelOchText(code, codeRow);
                    break;

                case "Variabel":
                    VariableMethods.Variabel(code, codeRow);
                    break;

                case "LäsIn":
                    LäsMethods.LäsIn(code, codeRow);
                    break;
                case "LäsInklTitel":
                    LäsMethods.LäsInklTitel(code, codeRow);
                    break;

                case "RäknaUtVariabel":
                    RäknaUtMethods.RäknaUtVariabel(code, codeRow);
                    break;

                case "RäknaUt":
                    RäknaUtMethods.RäknaUt(code, codeRow);
                    break;
            }
        }
    }
}
