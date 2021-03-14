using System;
using System.Collections;
using System.Collections.Generic;
using Hack.VMTranslator.Lib.Input;
using Hack.VMTranslator.Lib.Models;

namespace Hack.VMTranslator.Lib.Commands.Functions
{
    public class ReturnTranslator : ICommandTranslator
    {
        private readonly CommandTranslatorFactory _factory;

        public ReturnTranslator(CommandTranslatorFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public IOutputCode Translate(VmCodeLine vmCommand)
        {
            var result = new List<string>();
            result.AddRange(StoreReturnAddress());
            result.AddRange(PlaceReturnValue());
            result.AddRange(RepositionStackPointer());
            result.AddRange(RestoreThat());
            result.AddRange(RestoreThis());
            result.AddRange(RestoreArg());
            result.AddRange(RestoreLocal());
            result.AddRange(GotoReturnAddress());
            
            return new AsmCode(result);
        }

        private IEnumerable<string> StoreReturnAddress()
        {
            return new[]
            {
                $"@{Constants.LocalBasePointer}",
                "D=M",
                "@5",
                "A=D-A",
                "D=M",
                "@R15",
                "M=D"
            };
        }

        private IEnumerable<string> PlaceReturnValue()
        {
            return _factory
                .GetTranslator(CommandType.Pop)
                .Translate(new VmCodeLine("pop argument 0"))
                .GetLines();
        }

        private IEnumerable<string> RepositionStackPointer()
        {
            return new[]
            {
                $"@{Constants.ArgumentBasePointer}",
                "D=M",
                $"@{Constants.StackPointer}",
                "M=D+1"
            };
        }

        private IEnumerable<string> RestoreThat()
        {
            return new[]
            {
                $"@{Constants.LocalBasePointer}",
                "A=M-1",
                "D=M",
                $"@{Constants.ThatBasePointer}",
                "M=D"
            };
        }

        private IEnumerable<string> RestoreThis() =>
            Restore(2, Constants.ThisBasePointer);

        private IEnumerable<string> RestoreArg() =>
            Restore(3, Constants.ArgumentBasePointer);
        
        private IEnumerable<string> RestoreLocal() =>
            Restore(4, Constants.LocalBasePointer);

        private IEnumerable<string> GotoReturnAddress()
        {
            return new[]
            {
                "@R15",
                "A=M",
                "0;JMP"
            };
        }

        private IEnumerable<string> Restore(int addressDistance, int basePointerAddress)
        {
            return new[]
            {
                $"@{addressDistance}",
                "D=A",
                $"@{Constants.LocalBasePointer}",
                "A=M-D",
                "D=M",
                $"@{basePointerAddress}",
                "M=D"
            };
        }
    }
}