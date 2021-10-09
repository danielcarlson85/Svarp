using Svarp.Methods;
using SWarp.FileHandler;
using SWarp.Methods;
using SWarp.Validators;
using System;
using System.Threading.Tasks;

namespace Svarp
{
    class Program
    {

        static async Task Main(string[] args)
        {
            Code Code = new();
            var file = await FileHandler.LoadFromFile(args);

            Code = CodeValidator.ValidateCode(Code, file);

            Run(Code);
            Console.Read();
        }

        private static void Run(Code code)
        {
            foreach (var codeRow in code.CodeRows)
            {
                switch (codeRow.FunctionName)
                {
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
                        RäknaUtMethods.RäknaUtVariable(code, codeRow);
                        break;

                    case "RäknaUt":
                        RäknaUtMethods.RäknaUt(code, codeRow);
                        break;
                }
            }
        }
    }
}
