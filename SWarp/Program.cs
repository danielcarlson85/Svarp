

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
        //foreach (var code in Code.code)
        //{
        //    Console.WriteLine(code);
        //}

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
        var exceptions = new List<exceptionList>();

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
            exceptions.Add(new exceptionList() { exception = e, MethodName = activecoderow, CodeRowNumber = codeRowNumber });

            foreach (var item in exceptions)
            {
                Console.WriteLine("\n\nException: Method name: " + item.MethodName + " \n" + "On row" + item.CodeRowNumber + "\n\n" + item.exception);
            }

            throw;
        }
    }

    class exceptionList
    {
        public Exception exception { get; set; }
        public string MethodName { get; set; }
        public int CodeRowNumber { get; set; }
    }
}
