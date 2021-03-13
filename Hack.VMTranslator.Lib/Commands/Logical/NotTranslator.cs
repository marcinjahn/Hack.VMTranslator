using System.Collections.Generic;

namespace Hack.VMTranslator.Lib.Commands.Logical
{
    public class NotTranslator : ArgumentlessTranslatorBase
    {
        protected override IEnumerable<string> GetAsmLines()
        {
            return new[]
            {
                $"@{Constants.StackPointer}",
                "A=M-1",
                "M=!M"
            };
        }
    }
}