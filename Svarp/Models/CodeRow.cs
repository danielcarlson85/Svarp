using System.Collections.Generic;

namespace Svarp
{
    public class CodeRow
    {
        //public List<StringVariable> StringVariables { get; set; } = new List<StringVariable>();
        public string RowVariableName { get; set; } = string.Empty;
        public string RowText { get; set; } = string.Empty;
        //  public MethodType MethodType { get; set; }
        public string FunctionName { get; set; } = string.Empty;
        public string RowVariableValue { get; internal set; } = string.Empty;
        public string Operator { get; internal set; } = string.Empty;
        public CodeRow Delegate { get; set; }
    }
}