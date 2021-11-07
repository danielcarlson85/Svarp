using System.Collections.Generic;

namespace Swarp.Common.Models
{
    public class ProgramCode
    {
        public List<Variables> StringVariables { get; set; } = new List<Variables>();
        public List<ProgramMethods> Methods { get; set; } = new();

        public List<ProgramCodeOnRow> CodeRows { get; set; } = new();
    }
}
