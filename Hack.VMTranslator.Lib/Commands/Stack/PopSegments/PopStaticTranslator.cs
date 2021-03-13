using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace Hack.VMTranslator.Lib.Commands.Stack.PopSegments
{
    public class PopStaticTranslator : PushPopTranslatorBase
    {
        private readonly PopStaticTranslatorOptions _options;

        public PopStaticTranslator(IOptions<PopStaticTranslatorOptions> options)
        {
            _options = options.Value;
        }

        protected override IEnumerable<string> GetAsmLines(string argument)
        {
            return new[]
            {
                $"@{Constants.StackPointer}",
                "AM=M-1",
                "D=M",
                $"@{_options.FileName}.{argument}",
                "M=D"
            };
        }
    }
}