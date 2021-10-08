namespace Svarp
{
    public class StringVariable
    {
        public int Order { get; set; } = 0;
        public string VariableName { get; set; } = string.Empty;
        public string VariableInputValue { get; set; } = string.Empty;
        public VariableType VariableType { get; set; }
    }
}
