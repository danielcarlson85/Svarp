using System;
using System.Collections.Generic;
using Models.Exceptions;
using Svarp;

namespace SWarp.Runtime
{
    public class Runtime
    {
        public static void RunCode(ProgramCode programCode)
        {
            var exceptions = new List<ExceptionList>();
            var activecoderow = string.Empty;
            var codeRowNumber = 0;

            try
            {
                foreach (var codeRow in programCode.CodeRows)
                {
                    //Change here to debug SWarp
                    if (codeRow.CodeRowNumber == 48)
                    {
                        Console.WriteLine("nu");
                    }

                    codeRowNumber = codeRow.CodeRowNumber;
                    activecoderow = codeRow.FullCodeOnRow;
                    Intepreter.Run(programCode, codeRow);
                }
            }
            catch (Exception e)
            {
                exceptions.Add(new ExceptionList() { exception = e, MethodName = activecoderow, CodeRowNumber = codeRowNumber });

                foreach (var item in exceptions)
                {
                    Console.WriteLine("\n\nException: Method name: " + item.MethodName + " \n" + "On row" + item.CodeRowNumber + "\n\n" + item.exception);
                }

                throw;
            }
        }
    }
}
