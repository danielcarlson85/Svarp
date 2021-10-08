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
            var svarpFile = "test.sv";
            var file = await File.ReadAllLinesAsync(svarpFile);

            foreach (var row in file)
            {
                if (string.IsNullOrEmpty(row))
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
                        Methods.Skriv(code, codeRow);
                        break;

                    case "Variable":
                        Methods.Variable(code, codeRow);
                        break;

                    case "Läs":
                        Methods.Läs(code, codeRow);
                        break;
                }
            }
        }
    }
}
