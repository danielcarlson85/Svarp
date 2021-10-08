using System.Collections.Generic;

namespace Svarp
{
    public class CodeRow
    {
        //public List<StringVariable> StringVariables { get; set; } = new List<StringVariable>();
        public string RowVariableName { get; set; }
        public string RowText { get; set; }
      //  public MethodType MethodType { get; set; }
        public string FunctionName { get; set; }
        public string RowVariableValue { get; internal set; }
    }
}