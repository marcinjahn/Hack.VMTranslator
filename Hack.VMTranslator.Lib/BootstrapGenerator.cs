using System;
using System.Linq;
using Hack.VMTranslator.Lib.Commands;
using Hack.VMTranslator.Lib.Input;
using Hack.VMTranslator.Lib.Models;

namespace Hack.VMTranslator.Lib
{
    public class BootstrapGenerator
    {
        private readonly CommandTranslatorFactory _factory;

        public BootstrapGenerator(CommandTranslatorFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public IOutputCode GetBootstrapCode()
        {
            return new AsmCode(
                new[]
                {
                    "@256",
                    "D=A",
                    $"@{Constants.StackPointer}",
                    "M=D"
                }.Concat(
                    _factory
                        .GetTranslator(CommandType.Call)
                        .Translate(new VmCodeLine("call Sys.init 0"))
                        .GetLines()));
        }
    }
}