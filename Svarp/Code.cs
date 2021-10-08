using System.Collections.Generic;

namespace Svarp
{
    class Code
    {
        public List<StringVariable> StringVariables { get; set; } = new List<StringVariable>();

        public List<CodeRow> CodeRows { get; set; } = new();
    }
}
