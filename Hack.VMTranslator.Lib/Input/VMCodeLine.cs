using System;
using System.Collections.Generic;

namespace Hack.VMTranslator.Lib.Input
{
    public class VMCodeLine : IInputCodeLine
    {
        public VMCodeLine(string code)
        {
            Code = code ?? throw new ArgumentNullException(nameof(code));
        }
        
        public string Code { get; }
        public void AddTo(ICollection<VMCodeLine> lines)
        {
            lines.Add(this);
        }
    }
}