using System;

namespace Hack.VMTranslator.Lib.Input
{
    public class LineCleaner
    {
        public IInputCodeLine Clean(string line)
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
                return Clean(line.Substring(0, indexOfComment));
            }
            else
            {
                return new VMCodeLine(trimmed);
            }
        }
    }
}