using System;

namespace Hack.VMTranslator.Lib.Input
{
    public class InputCodeLineFactory
    {
        public IInputCodeLine GetCodeLine(string line, string fileName)
        {
            var trimmed = line.Trim();
            var indexOfComment = line.IndexOf("//", StringComparison.Ordinal);
            
            if (string.IsNullOrWhiteSpace(trimmed))
            {
                return new VoidCodeLine();
            }
            else if (trimmed.StartsWith("//"))
            {
                return new VoidCodeLine();
            }
            else if (indexOfComment > 0)
            {
                return GetCodeLine(line.Substring(0, indexOfComment), fileName);
            }
            else
            {
                return new VmCodeLine(trimmed, fileName);
            }
        }
    }
}