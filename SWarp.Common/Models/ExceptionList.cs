using System;

namespace Swarp.Common.Models
{ 
    public class ExceptionList
    {
        public Exception exception { get; set; }
        public string MethodName { get; set; }
        public int CodeRowNumber { get; set; }
    }
}
