using SWarp.Models;
using System.Collections.Generic;

namespace Svarp
{
    public class ProgramCode
    {
        public List<Variables> StringVariables { get; set; } = new List<Variables>();
        public List<ProgramMethods> Methods { get; set; } = new();

        public List<ProgramCodeOnRow> CodeRows { get; set; } = new();
    }
}
