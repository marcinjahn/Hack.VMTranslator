using System.Collections.Generic;

namespace Hack.VMTranslator.Lib.Input
{
    public class VoidCodeLine : IInputCodeLine
    {
        public string Code { get; } = null;

        public void AddTo(ICollection<VMCodeLine> lines)
        {
        }
    }
}