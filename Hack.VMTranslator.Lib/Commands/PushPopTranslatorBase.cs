using System.Collections.Generic;
using Hack.VMTranslator.Lib.Extensions;
using Hack.VMTranslator.Lib.Input;
using Hack.VMTranslator.Lib.Models;

namespace Hack.VMTranslator.Lib.Commands
{
    public abstract class PushPopTranslatorBase : ICommandTranslator
    {
        public IOutputCode Translate(VMCodeLine vmCommand)
        {
            var argument = vmCommand.GetSecondArgument();
            return new AsmCode(GetAsmLines(argument));
        }

        protected abstract IEnumerable<string> GetAsmLines(string argument);
    }
}