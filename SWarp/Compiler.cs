using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;

namespace SWarp
{
    class Compiler
    {
        public static void Compile(string fileToCompile)
        {
            var cod = new List<string>{
                "public static class Code",
                "{",
                        "public static string[] code = new string[]",
                        "{",
            };

            var codeEnd = new List<string>
            {
                "};",
                "}"
            };

            var s = File.ReadAllLines(fileToCompile);

            foreach (var item in s)
            {

                string tempCode = $"\"{item}\",";
                cod.Add(tempCode);
            }

            cod.AddRange(codeEnd);

            string startupPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName);

            File.WriteAllLines(startupPath + "/Code.cs", cod);

            Thread.Sleep(2000);
           // CompileDotNet();
        }

        public static void CompileDotNet()
        {
            string startupPath = "\"" + Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName) + "\"";

            Console.WriteLine(startupPath);


            Process ptStitcher = new Process();
            ptStitcher.StartInfo.FileName = "dotnet";
            ptStitcher.StartInfo.Arguments = "publish -r win-x64 -p:PublishSingleFile=true --self-contained true " + startupPath;
            ptStitcher.Start();
            Environment.Exit(0);
        }
    }
}
