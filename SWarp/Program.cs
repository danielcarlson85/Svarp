using SWarp;
using SWarp.FileHandler;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Svarp
{
    class Program
    {
        static ProgramCode ProgramCode = new();

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
            var file = await FileHandler.LoadFromFile(args);
            ProgramCode = Lexer.LexCode(ProgramCode, file);

            foreach (var codeRow in ProgramCode.CodeRows)
            {
                Intepreter.Run(ProgramCode, codeRow);
            }
        }


        static void Loop()
        {
            int nummer = 0;

            while (nummer < 100000)
            {
                //Console.WriteLine(nummer + "Hello world");
                nummer++;
            }
        }


    }
}
