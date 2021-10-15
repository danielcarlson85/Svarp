

using Svarp;
using SWarp;
using SWarp.FileHandler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        foreach (var code in Code.code)
        {
            Console.WriteLine(code);
        }
        Stopwatch stopwatch = new();
        stopwatch.Start();
        await Run(args);
        //Loop();
        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed);
        Console.Read();
    }

    static async Task Run(string[] args)
    {
        ProgramCode programCode = new ProgramCode();

#if DEBUG
        string[] code = new string[]
        {
        "(SkrivUt)'hej'",
        "(SkrivUt)'hej'",
        };

        var file = await FileHandler.LoadFromFile(args);
        programCode = Lexer.LexCode(programCode, file.ToList());

#else

        if (args.Length != 0)
        {
            {
                if (args.Contains("--compile"))
                {
                    Compiler.Compile(args[1], args[2]);
                    Console.WriteLine("Program is compiled");
                }
            }
        }

        if (args.Length == 0)
        {
            programCode = Lexer.LexCode(programCode, Code.code.ToList());
        }
#endif

        foreach (var codeRow in programCode.CodeRows)
        {
            Intepreter.Run(programCode, codeRow);
        }
    }
}
