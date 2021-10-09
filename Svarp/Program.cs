﻿using Svarp.Methods;
using SWarp;
using SWarp.FileHandler;
using SWarp.Methods;
using SWarp.Validators;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Svarp
{
    class Program
    {
        static Code Code = new();

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

        static void Loop()
        {
            int nummer = 0;

            while (nummer < 200000)
            {
                Console.WriteLine(nummer + "Hello world");
                nummer++;
            }
        }


        static async Task Run(string[] args)
        {

            var file = await FileHandler.LoadFromFile(args);

            Code = CodeValidator.ValidateCode(Code, file);

            foreach (var codeRow in Code.CodeRows)
            {
                Intepreter.Run(Code, codeRow);
            }
        }
    }
}
