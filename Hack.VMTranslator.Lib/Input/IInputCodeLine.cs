using System.Collections.Generic;

namespace Hack.VMTranslator.Lib.Input
{
    public interface IInputCodeLine
    {
        public string Code { get; }
        public void AddTo(ICollection<VMCodeLine> lines);
    }
}