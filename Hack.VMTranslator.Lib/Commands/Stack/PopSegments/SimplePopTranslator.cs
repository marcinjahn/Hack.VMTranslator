using System.Collections.Generic;

namespace Hack.VMTranslator.Lib.Commands.Stack.PopSegments
{
    public abstract class SimplePopTranslator : PushPopTranslatorBase
    {
        private readonly int _segmentBaseAddressPointer;

        protected SimplePopTranslator(int segmentBaseAddressPointer)
        {
            _segmentBaseAddressPointer = segmentBaseAddressPointer;
        }

        protected override IEnumerable<string> GetAsmLines(string argument)
        {
            return new string[]
            {
                $"@{argument}",
                "D=A",
                $"@{_segmentBaseAddressPointer}",
                "D=D+M",
                "@R13",
                "M=D",
                $"@{Constants.StackPointer}",
                "AM=M-1",
                "D=M",
                "@R13",
                "A=M",
                "M=D"
            };
        }
    }
}