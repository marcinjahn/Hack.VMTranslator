using System;
using Hack.VMTranslator.Lib.Commands.Stack.PopSegments;
using Hack.VMTranslator.Lib.Input;
using Hack.VMTranslator.Lib.Models;
using Hack.VMTranslator.Lib.Resolvers;

namespace Hack.VMTranslator.Lib.Commands.Stack
{
    public class PopTranslator : ICommandTranslator
    {
        private readonly PopTranslatorFactory _factory;
        private readonly MemorySegmentResolver _typeResolver;

        public PopTranslator(PopTranslatorFactory factory, MemorySegmentResolver typeResolver)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _typeResolver = typeResolver ?? throw new ArgumentNullException(nameof(typeResolver));
        }
        
        public IOutputCode Translate(VMCodeLine vmCommand)
        {
            var type = _typeResolver.Resolve(vmCommand);
            var translator = _factory.GetTranslator(type);
            return translator.Translate(vmCommand);
        }
    }
}