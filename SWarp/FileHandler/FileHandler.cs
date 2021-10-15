using System.IO;
using System.Threading.Tasks;

namespace SWarp.FileHandler
{
    class FileHandler
    {
        public static async Task<string[]> LoadFromFile(string[] args)
        {
            return (await File.ReadAllLinesAsync(args[1]));
        }
    }
}
