using System.Collections.Generic;

namespace Hack.VMTranslator.Lib.Commands.Stack.PushSegments
{
    public class PushPointerTranslator : PushPopTranslatorBase
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
                $"@{(argument == "0" ? Constants.ThisBasePointer : Constants.ThatBasePointer)}",
                "D=M",
                "@R13",
                "A=M",
                "M=D"
            };
        }
    }
}