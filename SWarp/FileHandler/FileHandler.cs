using System.IO;
using System.Threading.Tasks;

namespace SWarp.FileHandler
{
    class FileHandler
    {
        public static async Task<string[]> LoadFromFile(string fileName)
        {
            return (await File.ReadAllLinesAsync(fileName));
        }
    }
}
