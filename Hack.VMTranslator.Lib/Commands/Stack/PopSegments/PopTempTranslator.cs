using System.Collections.Generic;

namespace Hack.VMTranslator.Lib.Commands.Stack.PopSegments
{
    public class PopTempTranslator : PushPopTranslatorBase
    {
        protected override IEnumerable<string> GetAsmLines(string argument)
        {
            return new string[]
            {
                $"@{argument}",
                "D=A",
                $"@{Constants.TempBaseAddress}",
                "D=D+A",
                "@R13",
                "M=D",
                $"@{Constants.StackPointer}",
                "AM=M-1",
                "D=M",
                "@R13",
                "A=M",
                "M=D"
            };
        }
    }
}