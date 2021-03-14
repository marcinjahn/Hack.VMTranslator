using System.Collections.Generic;

namespace Hack.VMTranslator.Lib.Input
{
    public interface IInputCodeLine
    {
        public string Code { get; }
        public string FileName { get; set; }
        public void AddTo(ICollection<VmCodeLine> lines);
    }
}