using Svarp.Methods;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Svarp
{
    class Program
    {
        static Code Code = new Code();

        static async Task Main(string[] args)
        {
            var SWarpFile = "test.sv";
            var file = await File.ReadAllLinesAsync(SWarpFile);

            foreach (var row in file)
            {
                if (string.IsNullOrEmpty(row))
                {
                    continue;
                }
                if (row.StartsWith("//"))
                {
                    continue;
                }

                Code = Lexer.LexCode(Code, row);
            }

            Run(Code);
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
                }
            }
        }
    }
}
