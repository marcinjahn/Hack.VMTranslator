using System.Collections.Generic;

namespace Hack.VMTranslator.Lib.Commands.PushSegments
{
    public class PushConstantTranslator : PushPopTranslatorBase
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
                "@R13",
                "A=M",
                "M=D"
            };
        }
    }
}