using System.IO;
using System.Threading.Tasks;

namespace SWarp.Common
{
    public static class FileHandler
    {
        public static async Task<string[]> LoadFromFile(string fileName)
        {
            return (await File.ReadAllLinesAsync(fileName));
        }
    }
}
