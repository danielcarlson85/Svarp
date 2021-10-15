﻿

using Svarp;
using SWarp;
using SWarp.FileHandler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

partial class Program
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

    static ProgramCode programCode = new ProgramCode();


    static async Task Run(string[] args)
    {

        Console.WriteLine("innan main");

        if (args.Length != 0)
        {

            switch (args[0])
            {
                case "-f":
                    var file = await FileHandler.LoadFromFile(args);
                    programCode = Lexer.LexCode(programCode, file.ToList());
                    RunCode();

                    break;

                case "--compile":
                    Compiler.Compile(args[1]);
                    Console.WriteLine("Program is compiled");
                    break;

                default:
                    var code = new string[]
                    {
                        "(SkrivUt)'hej'",
                        "(SkrivUt)'hej'",
                        "(SkrivUt)'Från kod array'"
                    };
                    programCode = Lexer.LexCode(programCode, code.ToList());
                    RunCode();
                    break;
            }
        }
        else
        {
            programCode = Lexer.LexCode(programCode, Code.code.ToList());
            RunCode();
        }

       
    }

    static void RunCode()
    {
        Console.WriteLine("Efter switch");

        var exceptions = new List<ExceptionList>();

        var activecoderow = string.Empty;
        var codeRowNumber = 0;


        try
        {

            foreach (var codeRow in programCode.CodeRows)
            {
                if (codeRow.CodeRowNumber == 48)
                {
                    Console.WriteLine("nu");
                }

                codeRowNumber = codeRow.CodeRowNumber;
                activecoderow = codeRow.FullCodeOnRow;
                Intepreter.Run(programCode, codeRow);
            }

        }
        catch (Exception e)
        {
            exceptions.Add(new ExceptionList() { exception = e, MethodName = activecoderow, CodeRowNumber = codeRowNumber });

            foreach (var item in exceptions)
            {
                Console.WriteLine("\n\nException: Method name: " + item.MethodName + " \n" + "On row" + item.CodeRowNumber + "\n\n" + item.exception);
            }

            throw;
        }
    }
}
