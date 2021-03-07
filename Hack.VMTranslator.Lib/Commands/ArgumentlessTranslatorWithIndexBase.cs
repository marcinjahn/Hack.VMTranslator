using System.Collections.Generic;

namespace Hack.VMTranslator.Lib.Commands
{
    public abstract class ArgumentlessTranslatorWithIndexBase : ArgumentlessTranslatorBase
    {
        protected int Index { get; set; }
        protected override IEnumerable<string> GetAsmLines()
        {
            Index++;
            return ActualGetAsmLines();
        }

        protected abstract IEnumerable<string> ActualGetAsmLines();
    }
}