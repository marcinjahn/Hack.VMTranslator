using System.Collections.Generic;

namespace Hack.VMTranslator.Lib.Input
{
    public class VoidCodeLine : IInputCodeLine
    {
        public string Code { get; } = null;
        public string FileName { get; set; }

        public void AddTo(ICollection<VmCodeLine> lines)
        {
        }
    }
}