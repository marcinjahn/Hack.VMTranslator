using System.Collections.Generic;

namespace Hack.VMTranslator.Lib.Commands.Arithmetic
{
    public class NegTranslator : ArgumentlessTranslatorBase
    {
        protected override IEnumerable<string> GetAsmLines()
        {
            return new[]
            {
                $"@{Constants.StackPointer}",
                "A=M-1",
                "M=-M"
            };
        }
    }
}