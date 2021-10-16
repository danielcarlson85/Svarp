

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Svarp;

namespace SWarp
{
    public static class Program
    {
        static string SWFileName = "Calc.sw";
        static string rootPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName) + "\\";

        static async Task Main(string[] args)
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();
            await Run(args);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            Console.Read();
        }

        static ProgramCode programCode = new();

        static async Task Run(string[] args)
        {
            Console.WriteLine("innan main");

            if (args.Length != 0)
            {
                switch (args[0])
                {
                    case "-f":
                        var fileName = args[1];
                        var file = await FileHandler.LoadFromFile(fileName);
                        programCode = Lexer.LexCode(programCode, file.ToList());
                        Runtime.RunCode(programCode);

                        break;

                    case "--compile":
                        Compiler.Compile(args[1]);
                        Console.WriteLine("Program is compiled");
                        break;

                    default:
                        break;
                }
            }
            else
            {
                if (Debugger.IsAttached)
                {
                    var fileName = $"{rootPath}{SWFileName}";
                    var file = await FileHandler.LoadFromFile(fileName);

                    programCode = Lexer.LexCode(programCode, file.ToList());
                    Runtime.RunCode(programCode);
                }
                else
                {
                    programCode = Lexer.LexCode(programCode, Code.code.ToList());
                    Runtime.RunCode(programCode);
                }
            }
        }
    }

}
