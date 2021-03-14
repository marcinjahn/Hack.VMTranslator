using System;
using System.Linq;
using Hack.VMTranslator.Lib.Commands;
using Hack.VMTranslator.Lib.Input;

namespace Hack.VMTranslator.Lib.Resolvers
{
    public class CommandTypeResolver
    {
        public CommandType Resolve(VmCodeLine line)
        {
            if (line == null) throw new ArgumentNullException(nameof(line));
            
            var command = line.Code.Split(' ').First();

            return command switch
            {
                "push" => CommandType.Push,
                "pop" => CommandType.Pop,
                "add" => CommandType.Add,
                "sub" => CommandType.Sub,
                "and" => CommandType.And,
                "or" => CommandType.Or,
                "not" => CommandType.Not,
                "neg" => CommandType.Neg,
                "eq" => CommandType.Eq,
                "gt" => CommandType.Gt,
                "lt" => CommandType.Lt,
                "label" => CommandType.Label,
                "goto" => CommandType.Goto,
                "if-goto" => CommandType.IfGoto,
                "function" => CommandType.Function,
                "call" => CommandType.Call,
                "return" => CommandType.Return,
                _ => throw new ArgumentOutOfRangeException(nameof(line))
            };
        }
    }
}