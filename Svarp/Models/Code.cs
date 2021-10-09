using SWarp.Models;
using System.Collections.Generic;

namespace Svarp
{
    public class Code
    {
        public List<StringVariable> StringVariables { get; set; } = new List<StringVariable>();
        public List<Method> Methods { get; set; } = new();

        public List<CodeRow> CodeRows { get; set; } = new();
    }
}
