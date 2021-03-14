using System;
using System.Collections.Generic;
using Hack.VMTranslator.Lib.Commands;
using Hack.VMTranslator.Lib.Input;
using Hack.VMTranslator.Lib.Models;
using Hack.VMTranslator.Lib.Resolvers;
using Microsoft.Extensions.Options;

namespace Hack.VMTranslator.Lib
{
    public class VMTranslator
    {
        public VMTranslator(CommandTranslatorFactory factory, CommandTypeResolver resolver,
            BootstrapGenerator bootstrap, IOptions<VMTranslatorOptions> options)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
            _bootstrap = bootstrap ?? throw new ArgumentNullException(nameof(bootstrap));
            _options = options.Value;
        }

        private readonly CommandTranslatorFactory _factory;
        private readonly CommandTypeResolver _resolver;
        private readonly BootstrapGenerator _bootstrap;
        private readonly VMTranslatorOptions _options;

        public IOutputCode Translate(IEnumerable<VmCodeLine> lines)
        {
            var output = new AsmCode();

            if (_options.IncludeBootstrap)
            {
                var bootstrapCode = _bootstrap.GetBootstrapCode();
                output.AppendCode(bootstrapCode);
            }

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