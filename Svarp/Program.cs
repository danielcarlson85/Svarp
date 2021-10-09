using Svarp.Methods;
using SWarp;
using SWarp.FileHandler;
using SWarp.Methods;
using SWarp.Validators;
using System;
using System.Threading.Tasks;

namespace Svarp
{
    class Program
    {
        public static Code Code = new();


        static async Task Main(string[] args)
        {
            var file = await FileHandler.LoadFromFile(args);

            Code = CodeValidator.ValidateCode(Code, file);

            foreach (var codeRow in Code.CodeRows)
            {
                Intepreter.Run(Code, codeRow);
            }


            Console.Read();
        }

    }
}
