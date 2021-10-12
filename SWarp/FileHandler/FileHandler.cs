using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWarp.FileHandler
{
    class FileHandler
    {
        public static async Task<List<string>> LoadFromFile(string[] args)
        {
            if (args.Length > 0)
            {
                return (await File.ReadAllLinesAsync(args[0])).ToList();
            }
            else
            {
                var SWarpFile = "Calc.sw";
                return (await File.ReadAllLinesAsync(SWarpFile)).ToList();
            }
        }
    }
}
