using System.Collections.Generic;

namespace Hack.VMTranslator.Lib.Commands
{
    public class LtTranslator : ArgumentlessTranslatorWithIndexBase
    {
        protected override IEnumerable<string> ActualGetAsmLines()
        {
            return new[]
            {
                $"@{Constants.StackPointer}",
                "AM=M-1",
                "D=M",
                "A=A-1",
                "D=M-D",
                $"@LT_TRUE{Index}",
                "D;JLT",
                $"@{Constants.StackPointer}",
                "A=M-1",
                "M=0",
                $"@LT_END{Index}",
                "0;JMP",
                $"(LT_TRUE{Index})",
                $"@{Constants.StackPointer}",
                "A=M-1",
                "M=-1",
                $"(LT_END{Index})"
            };
        }
    }
}