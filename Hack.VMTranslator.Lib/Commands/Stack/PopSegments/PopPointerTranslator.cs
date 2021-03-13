using System.Collections.Generic;

namespace Hack.VMTranslator.Lib.Commands.Stack.PopSegments
{
    public class PopPointerTranslator : PushPopTranslatorBase
    {
        protected override IEnumerable<string> GetAsmLines(string argument)
        {
            return new[]
            {
                $"@{Constants.StackPointer}",
                "AM=M-1",
                "D=M",
                $"@{(argument == "0" ? Constants.ThisBasePointer : Constants.ThatBasePointer)}",
                "M=D"
            };
        }
    }
}