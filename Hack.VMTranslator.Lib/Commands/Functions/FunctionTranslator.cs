using System;
using System.Collections.Generic;
using Hack.VMTranslator.Lib.Extensions;
using Hack.VMTranslator.Lib.Input;
using Hack.VMTranslator.Lib.Models;

namespace Hack.VMTranslator.Lib.Commands.Functions
{
    public class FunctionTranslator : ICommandTranslator
    {
        private readonly CommandTranslatorFactory _factory;

        public FunctionTranslator(CommandTranslatorFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
        
        public IOutputCode Translate(VmCodeLine vmCommand)
        {
            var functionName = vmCommand.GetFirstArgument();
            var localVars = int.Parse(vmCommand.GetSecondArgument());

            var asmCode = new List<string>();
            
            asmCode.Add($"({functionName})");
            asmCode.AddRange(GenerateLocalIntitializationCode(localVars));

            return new AsmCode(asmCode);
        }

        private IEnumerable<string> GenerateLocalIntitializationCode(int localVarsNumber)
        {
            var push = _factory.GetTranslator(CommandType.Push);

            var result = new List<string>();

            for (var i = 0; i < localVarsNumber; i++)
            {
                result.AddRange(push.Translate(new VmCodeLine("push const 0")).GetLines());
            }

            return result;
        }
    }
}