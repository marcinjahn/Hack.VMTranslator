using Hack.VMTranslator.Lib.Extensions;
using Hack.VMTranslator.Lib.Input;
using Hack.VMTranslator.Lib.Models;

namespace Hack.VMTranslator.Lib.Commands.Stack.PopSegments
{
    public class PopStaticTranslator : ICommandTranslator
    {
        public IOutputCode Translate(VmCodeLine vmCommand)
        {
            var argument = vmCommand.GetSecondArgument();
            return new AsmCode(new[]
            {
                $"@{Constants.StackPointer}",
                "AM=M-1",
                "D=M",
                $"@{vmCommand.FileName}.{argument}",
                "M=D"
            });
        }
    }
}