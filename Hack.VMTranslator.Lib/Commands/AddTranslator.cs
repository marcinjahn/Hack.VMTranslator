using System.Collections.Generic;
using Hack.VMTranslator.Lib.Models;

namespace Hack.VMTranslator.Lib.Commands
{
    public class AddTranslator : ArgumentlessTranslatorBase
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
                "D=D+A",
                $"@{Constants.StackPointer}",
                "A=M-1",
                "M=D"
            };
        }
    }
}