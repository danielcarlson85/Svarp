﻿using System.Collections.Generic;

namespace Svarp
{
    public class ProgramCodeOnRow
    {
        public string FullCodeOnRow { get; set; } = string.Empty;
        public List<Variables> RowVariables { get; set; } = new();
        public string RowText { get; set; } = string.Empty;
        public string MethodName { get; set; } = string.Empty;
        public string RowVariableValue { get; internal set; } = string.Empty;
        public string Operator { get; internal set; } = string.Empty;


        public List<string> OmValue { get; set; } = new();
        
        public string OmOperator { get; set; } = string.Empty;
        public ProgramCodeOnRow Delegate { get; set; }
    }
}