using System.Collections.Generic;

namespace Hack.VMTranslator.Lib.Commands
{
    public class GtTranslator : ArgumentlessTranslatorWithIndexBase
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
                $"@GT_TRUE{Index}",
                "D;JGT",
                $"@{Constants.StackPointer}",
                "A=M-1",
                "M=0",
                $"@GT_END{Index}",
                "0;JMP",
                $"(GT_TRUE{Index})",
                $"@{Constants.StackPointer}",
                "A=M-1",
                "M=-1",
                $"(GT_END{Index})"
            };
        }
    }
}