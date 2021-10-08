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
                    case "Skriv":
                        SkrivMethods.Skriv(code, codeRow);
                        break;

                    case "Variable":
                        VariableMethods.Variable(code, codeRow);
                        break;

                    case "Läs":
                        LäsMethods.Läs(code, codeRow);
                        break;

                    case "RäknaUt":
                        RäknaUtMethods.RäknaUt(code, codeRow);
                        break;
                }
            }
        }
    }
}
