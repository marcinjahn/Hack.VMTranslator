using Hack.VMTranslator.Lib.Extensions;
using Hack.VMTranslator.Lib.Input;
using Hack.VMTranslator.Lib.Models;

namespace Hack.VMTranslator.Lib.Commands.Stack.PushSegments
{
    public class PushStaticTranslator : ICommandTranslator
    {
        public IOutputCode Translate(VmCodeLine vmCommand)
        {
            var argument = vmCommand.GetSecondArgument();

            return new AsmCode(new[]
            {
                $"@{Constants.StackPointer}",
                "D=M",
                "M=M+1",
                "@R13",
                "M=D",
                $"@{vmCommand.FileName}.{argument}",
                "D=M",
                "@R13",
                "A=M",
                "M=D"
            });
        }
    }
}