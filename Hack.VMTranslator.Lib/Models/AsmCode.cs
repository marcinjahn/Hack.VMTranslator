using System;
using System.Collections;
using System.Collections.Generic;

namespace Hack.VMTranslator.Lib.Models
{
    public class AsmCode : IOutputCode
    {
        private readonly List<string> _lines = new();

        public AsmCode()
        {
            
        }
        
        public AsmCode(IEnumerable<string> lines)
        {
            if (lines == null) throw new ArgumentNullException(nameof(lines));
            _lines.AddRange(lines);
        }

        public IOutputCode AppendCode(IOutputCode code)
        {
            _lines.AddRange(code.GetLines());
            return this;
        }

        public IEnumerable<string> GetLines()
        {
            return _lines;
        }
    }
}