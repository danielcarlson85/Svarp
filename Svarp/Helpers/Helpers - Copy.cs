//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Svarp
//{
//    static class Helpers
//    {
//        public static string GetVariableNames(string rowCode, string startCharacter, string stopCharacter)
//        {
//            var row = rowCode.Split('}','{');




//            if (rowCode.Contains(startCharacter) && rowCode.Contains(stopCharacter))
//            {
//                int Start, End;
//                Start = rowCode.IndexOf(startCharacter, 0) + startCharacter.Length;
//                End = rowCode.IndexOf(stopCharacter, Start);
//                return rowCode.Substring(Start, End - Start);
//            }

//            return string.Empty;
//        }

//        public static string GetFunctionName(string rowCode, string strStart, string strEnd)
//        {
//            if (rowCode.Contains(strStart) && rowCode.Contains(strEnd))
//            {
//                int Start, End;
//                Start = rowCode.IndexOf(strStart, 0) + strStart.Length;
//                End = rowCode.IndexOf(strEnd, Start);
//                var row = rowCode.Substring(Start, End - Start);



//                return row;
//            }

//            return string.Empty;
//        }

//        public static string GetFunction(string rowCode, string stopCharacter)
//        {
//            if (!string.IsNullOrWhiteSpace(rowCode))
//            {
//                int charLocation = rowCode.IndexOf(stopCharacter, StringComparison.Ordinal);

//                if (charLocation > 0)
//                {
//                    return rowCode.Substring(0, charLocation);
//                }
//            }

//            return string.Empty;
//        }

//        public static string GetFunctionInputText(string rowCode, string startCharacter, string stopCharacter)
//        {
//            if (rowCode.Contains(startCharacter) && rowCode.Contains(stopCharacter))
//            {
//                int Start, End;
//                Start = rowCode.IndexOf(startCharacter, 0) + startCharacter.Length;
//                End = rowCode.IndexOf(stopCharacter, Start);
//                return rowCode.Substring(Start, End - Start);
//            }

//            return string.Empty;
//        }
//    }
//}
