using System.Collections.Generic;

namespace Hack.VMTranslator.Lib.Commands
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