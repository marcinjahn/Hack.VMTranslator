using System.Collections.Generic;

namespace Hack.VMTranslator.Lib.Commands.Arithmetic
{
    public class SubTranslator : ArgumentlessTranslatorBase
    {
        protected override IEnumerable<string> GetAsmLines()
        {
            return new[]
            {
                $"@{Constants.StackPointer}",
                "AM=M-1",
                "A=A-1",
                "D=M",
                "@R13",
                "M=D",
                $"@{Constants.StackPointer}",
                "A=M",
                "D=M",
                "@R13",
                "A=M",
                "D=A-D",
                $"@{Constants.StackPointer}",
                "A=M-1",
                "M=D"
            };
        }
    }
}