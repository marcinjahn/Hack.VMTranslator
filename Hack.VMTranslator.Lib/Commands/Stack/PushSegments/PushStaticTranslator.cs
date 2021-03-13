using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace Hack.VMTranslator.Lib.Commands.Stack.PushSegments
{
    public class PushStaticTranslator : PushPopTranslatorBase
    {
        private readonly PushStaticTranslatorOptions _options;

        public PushStaticTranslator(IOptions<PushStaticTranslatorOptions> options)
        {
            _options = options.Value;
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
                $"@{_options.FileName}.{argument}",
                "D=M",
                "@R13",
                "A=M",
                "M=D"
            };
        }
    }
}