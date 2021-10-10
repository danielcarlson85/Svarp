using System.Collections.Generic;

namespace Svarp
{
    public class ProgramCodeOnRow
    {
        public string RowVariableName { get; set; } = string.Empty;
        public string RowText { get; set; } = string.Empty;
        public string MethodName { get; set; } = string.Empty;
        public string RowVariableValue { get; internal set; } = string.Empty;
        public string Operator { get; internal set; } = string.Empty;
        public ProgramCodeOnRow Delegate { get; set; }
    }
}