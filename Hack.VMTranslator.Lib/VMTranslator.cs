using System;
using System.Collections.Generic;
using Hack.VMTranslator.Lib.Commands;
using Hack.VMTranslator.Lib.Input;
using Hack.VMTranslator.Lib.Models;
using Hack.VMTranslator.Lib.Resolvers;

namespace Hack.VMTranslator.Lib
{
    public class VMTranslator
    {
        public VMTranslator(CommandTranslatorFactory factory, CommandTypeResolver resolver)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        private readonly CommandTranslatorFactory _factory;
        private readonly CommandTypeResolver _resolver;

        public IOutputCode Translate(IEnumerable<VMCodeLine> lines)
        {
            var output = new AsmCode();
            foreach (var line in lines)
            { 
                var type = _resolver.Resolve(line);
                var translator = _factory.GetTranslator(type);
                var result = translator.Translate(line);
                output.AppendCode(result);
            }

            return output;
        }
    }
}