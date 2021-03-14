using System.Collections.Generic;
using Hack.VMTranslator.Lib.Input;
using Hack.VMTranslator.Lib.Models;

namespace Hack.VMTranslator.Lib.Commands
{
    public abstract class ArgumentlessTranslatorBase : ICommandTranslator
    {
        public IOutputCode Translate(VmCodeLine vmCommand)
        {
            return new AsmCode(GetAsmLines());
        }

        protected abstract IEnumerable<string> GetAsmLines();
    }
}