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
        public static async Task<string[]> LoadFromFile(string[] args)
        {
            if (args.Length > 0)
            {
                return (await File.ReadAllLinesAsync(args[1]));
            }
            else
            {
                var SWarpFile = "test.sw";
                return (await File.ReadAllLinesAsync(SWarpFile));
            }
        }
    }
}
