using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SWarp
{
    class Compiler
    {
        static string solutionPathDebug = "\"" + Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.FullName) + "\\SWarp.sln\"";

        static string outputPathDebugCodeCS = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName);

        static string outputPathDebug = "\"" + Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.FullName) + "\"";


        static string solutionPathRelease = "\"" + Environment.CurrentDirectory + "\\Swarp.sln\"";

        static string outputPathRelease = "\"" + Environment.CurrentDirectory;

        static string outputPathReleaseCodeCS = Environment.CurrentDirectory + "\\Swarp\\";

        public static void Compile(string fileToCompile)
        {
            var code = new List<string> { "public static class Code", "{", "public static string[] code = new string[]", "{", };

            var codeEnd = new List<string> { "};", "}" };

            var fullCodeFileToCompile = File.ReadAllLines(fileToCompile);

            foreach (var codeRow in fullCodeFileToCompile)
            {

                string tempCode = $"\"{codeRow}\",";
                code.Add(tempCode);
            }

            code.AddRange(codeEnd);

            if (Debugger.IsAttached)
            {
                File.WriteAllLines(outputPathDebugCodeCS + "\\code.cs", code);
            }
            else
            {
                File.WriteAllLines(outputPathReleaseCodeCS + "\\Code.cs", code);
            }

            CompileToDotNet();
        }

        public static void CompileToDotNet()
        {
            string arg = string.Empty;

            if (Debugger.IsAttached)
            {
                Console.WriteLine("Debug");
                Console.WriteLine(solutionPathDebug);
                arg = $"publish -r win-x64 -p:PublishSingleFile=true --self-contained true {solutionPathDebug} -o {outputPathDebug}";
            }
            else
            {
                Console.WriteLine("publish");
                Console.WriteLine(solutionPathRelease);
                arg = $"publish -r win-x64 -p:PublishSingleFile=true --self-contained true {solutionPathRelease} -o {outputPathRelease}";
            }

            Process ptStitcher = new Process();
            ptStitcher.StartInfo.FileName = "dotnet";
            ptStitcher.StartInfo.Arguments = arg;
            ptStitcher.Start();
            Environment.Exit(0);
        }

    }


}
