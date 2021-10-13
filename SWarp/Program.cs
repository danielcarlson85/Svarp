

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

        if (args.Contains("--compile"))
        {
            Compiler.Compile(args[1]);
            Console.WriteLine("Program is compiled");
        }
        else
        {
            var file = await FileHandler.LoadFromFile(args);
            programCode = Lexer.LexCode(programCode, file.ToList());
        }

        foreach (var codeRow in programCode.CodeRows)
        {
            Intepreter.Run(programCode, codeRow);
        }
    }
}

