using System.Collections;
using System.Collections.Generic;
using Hack.VMTranslator.Lib.Extensions;
using Hack.VMTranslator.Lib.Models;

namespace Hack.VMTranslator.Lib.Commands.PopSegments
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