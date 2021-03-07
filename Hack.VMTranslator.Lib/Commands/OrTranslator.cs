using System;
using System.Collections.Generic;

namespace Hack.VMTranslator.Lib.Commands
{
    public class OrTranslator : ArgumentlessTranslatorBase
    {
        protected override IEnumerable<string> GetAsmLines()
        {
            return new[]
            {
                $"@{Constants.StackPointer}",
                "AM=M-1",
                "D=M",
                "@R13",
                "M=D",
                $"@{Constants.StackPointer}",
                "A=M-1",
                "D=M",
                "@R13",
                "A=M",
                "D=D|A",
                $"@{Constants.StackPointer}",
                "A=M-1",
                "M=D"
            };
        }
    }
}