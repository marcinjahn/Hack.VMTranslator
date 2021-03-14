using System;
using System.Collections.Generic;
using Hack.VMTranslator.Lib.Addressing;
using Hack.VMTranslator.Lib.Extensions;
using Hack.VMTranslator.Lib.Input;
using Hack.VMTranslator.Lib.Models;

namespace Hack.VMTranslator.Lib.Commands.Functions
{
    public class CallTranslator : ICommandTranslator
    {
        private readonly CommandTranslatorFactory _factory;

        public CallTranslator(CommandTranslatorFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public IOutputCode Translate(VmCodeLine vmCommand)
        {
            var functionName = vmCommand.GetFirstArgument();
            var argsCount = int.Parse(vmCommand.GetSecondArgument());

            var returnLabel = GenerateReturnLabel();
            
            var result = new List<string>();
            result.AddRange(MoveReturnAddressToStack(returnLabel));
            result.AddRange(MoveLclToStack());
            result.AddRange(MoveArgToStack());
            result.AddRange(GenerateThisToStack());
            result.AddRange(MoveThatToStack());
            result.AddRange(RepositionArg(argsCount));
            result.AddRange(RepositionLcl());
            result.AddRange(GotoFunction(functionName));
            result.AddRange(AddReturnLabel(returnLabel));
            
            return new AsmCode(result);
        }

        private IEnumerable<string> MoveReturnAddressToStack(string returnLabel)
        {
            return new[]
            {
                $"@{Constants.StackPointer}",
                "D=M",
                "M=M+1",
                "@R13",
                "M=D",
                $"@{returnLabel}",
                "D=A",
                "@R13",
                "A=M",
                "M=D"
            };
        }

        private string GenerateReturnLabel() =>
            $"RETURN.{ConsecutiveNumberGenerator.GetNext()}";

        private IEnumerable<string> AddReturnLabel(string label)
        {
            return new[]
            {
                $"({label})"
            };
        }

        private IEnumerable<string> GotoFunction(string functionName)
        {
            var gotoTranslator = _factory.GetTranslator(CommandType.Goto);
            return gotoTranslator
                .Translate(new VmCodeLine($"goto {functionName}"))
                .GetLines();
        }

        private IEnumerable<string> RepositionLcl()
        {
            return new[]
            {
                $"@{Constants.StackPointer}",
                "D=M",
                $"@{Constants.LocalBasePointer}",
                "M=D"
            };
        }

        private IEnumerable<string> RepositionArg(int argsCount)
        {
            return new[]
            {
                $"@{Constants.StackPointer}",
                "D=M",
                "@5",
                "D=D-A",
                $"@{argsCount}",
                "D=D-A",
                $"@{Constants.ArgumentBasePointer}",
                "M=D"
            };
        }
        
        private IEnumerable<string> MoveThatToStack()
        {
            return MoveAddressToStack(Constants.ThatBasePointer);
        }
        
        private IEnumerable<string> GenerateThisToStack()
        {
            return MoveAddressToStack(Constants.ThisBasePointer);
        }

        private IEnumerable<string> MoveLclToStack()
        {
            return MoveAddressToStack(Constants.LocalBasePointer);
        }
        
        private IEnumerable<string> MoveArgToStack()
        {
            return MoveAddressToStack(Constants.ArgumentBasePointer);
        }

        private IEnumerable<string> MoveAddressToStack(int segmentBasePointer)
        {
            return new[]
            {
                $"@{Constants.StackPointer}",
                "D=M",
                "M=M+1",
                "@R13",
                "M=D",
                $"@{segmentBasePointer}",
                "A=M",
                "D=A",
                "@R13",
                "A=M",
                "M=D"
            };
        }
    }
}