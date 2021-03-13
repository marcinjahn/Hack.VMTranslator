using System.Collections.Generic;

namespace Hack.VMTranslator.Lib.Commands.Stack.PushSegments
{
    public abstract class SimplePushTranslator : PushPopTranslatorBase
    {
        private readonly int _segmentBaseAddressPointer;

        protected SimplePushTranslator(int segmentBaseAddressPointer)
        {
            _segmentBaseAddressPointer = segmentBaseAddressPointer;
        }

        protected override IEnumerable<string> GetAsmLines(string argument)
        {
            return new[]
            {
                $"@{Constants.StackPointer}",
                "D=M",
                "M=M+1",
                "@R13",
                "M=D",
                $"@{argument}",
                "D=A",
                $"@{_segmentBaseAddressPointer}",
                "A=D+M",
                "D=M",
                "@R13",
                "A=M",
                "M=D"
            };
        } 
    }
}