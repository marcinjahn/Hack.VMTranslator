using Hack.VMTranslator.Lib.Extensions;
using Hack.VMTranslator.Lib.Input;
using Hack.VMTranslator.Lib.Models;

namespace Hack.VMTranslator.Lib.Commands.Branching
{
    public class LabelTranslator : ICommandTranslator
    {
        public IOutputCode Translate(VmCodeLine vmCommand)
        {
            var labelName = vmCommand.GetFirstArgument();
            return new AsmCode(new[] {$"({labelName})"});
        }
    }
}