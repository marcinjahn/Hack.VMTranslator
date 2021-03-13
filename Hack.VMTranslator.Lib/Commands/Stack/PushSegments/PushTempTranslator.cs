using System.Collections.Generic;

namespace Hack.VMTranslator.Lib.Commands.Stack.PushSegments
{
    public class PushTempTranslator : PushPopTranslatorBase
    {
        protected override IEnumerable<string> GetAsmLines(string argument)
        {
            return new[]
            {
                $"@{Constants.StackPointer}",
                "D=M",
                "M=M+1",
                "@R13",
                "M=D",
                $"@{argument}",
                "D=A",
                $"@{Constants.TempBaseAddress}",
                "A=D+A",
                "D=M",
                "@R13",
                "A=M",
                "M=D"
            };
        }
    }
}