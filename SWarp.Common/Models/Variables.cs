using Swarp.Common.Enums;

namespace Swarp.Common.Models
{
    public class Variables
    {
        public int Order { get; set; } = 0;
        public string VariableName { get; set; } = string.Empty;
        public string VariableValue { get; set; } = string.Empty;
        public VariableType VariableType { get; set; }
    }
}
