using System;
using System.Collections.Generic;

namespace Hack.VMTranslator.Lib.Input
{
    public class VmCodeLine : IInputCodeLine
    {
        
        public VmCodeLine(string code, string fileName = null)
        {
            Code = code ?? throw new ArgumentNullException(nameof(code));
            FileName = fileName;
        }
        
        public string Code { get; }
        public string FileName { get; set; }

        public void AddTo(ICollection<VmCodeLine> lines)
        {
            lines.Add(this);
        }
    }
}