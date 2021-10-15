using System.IO;
using System.Threading.Tasks;

namespace SWarp.FileHandler
{
    class FileHandler
    {
        public static async Task<string[]> LoadFromFile(string[] args)
        {
            if (args.Length > 0)
            {
                return (await File.ReadAllLinesAsync(args[0]));
            }
            else
            {
                string[] code = new string[]
                {
                        "(SkrivUt)'hej'",
                        "(SkrivUt)'hej'",
                        "(SkrivUt)'Från kod array'"
                };

                return code;

            }
        }
    }
}
