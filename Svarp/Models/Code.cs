using System.Collections.Generic;

namespace Svarp
{
    public class Code
    {
        public List<StringVariable> StringVariables { get; set; } = new List<StringVariable>();
        public List<CodeRow> CodeRows { get; set; } = new();
    }
}
