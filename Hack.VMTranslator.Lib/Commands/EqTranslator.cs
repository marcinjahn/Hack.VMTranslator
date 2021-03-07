using System.Collections.Generic;

namespace Hack.VMTranslator.Lib.Commands
{
    public class EqTranslator : ArgumentlessTranslatorWithIndexBase
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
                $"@EQ_TRUE{Index}",
                "D;JEQ",
                $"@{Constants.StackPointer}",
                "A=M-1",
                "M=0",
                $"@EQ_END{Index}",
                "0;JMP",
                $"(EQ_TRUE{Index})",
                $"@{Constants.StackPointer}",
                "A=M-1",
                "M=-1",
                $"(EQ_END{Index})"
            };
        }
    }
}