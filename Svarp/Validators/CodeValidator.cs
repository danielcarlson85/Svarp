using Svarp;
using System.Collections.Generic;

namespace SWarp.Validators
{
    class CodeValidator
    {
        public static Code ValidateCode(Code Code, List<string> file)
        {
            foreach (var row in file)
            {
                if (string.IsNullOrEmpty(row))
                {
                    continue;
                }
                if (row.StartsWith("--"))
                {
                    continue;
                }

                Code = Lexer.LexCode(Code, row);
            }

            return Code;
        }
    }
}
