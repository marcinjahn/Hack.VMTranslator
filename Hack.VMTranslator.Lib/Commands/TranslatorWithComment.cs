using System;
using Hack.VMTranslator.Lib.Input;
using Hack.VMTranslator.Lib.Models;

namespace Hack.VMTranslator.Lib.Commands
{
    public class TranslatorWithComment : ICommandTranslator
    {
        private readonly ICommandTranslator _innerTranslator;

        public TranslatorWithComment(ICommandTranslator innerTranslator)
        {
            _innerTranslator = innerTranslator ?? throw new ArgumentNullException(nameof(innerTranslator));
        }

        public IOutputCode Translate(VMCodeLine vmCommand)
        {
            var commentOutput = new AsmCode(new[] {$"// {vmCommand.Code}"});
            return commentOutput.AppendCode(_innerTranslator.Translate(vmCommand));
        }
    }
}