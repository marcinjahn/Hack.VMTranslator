using System.Collections;
using System.Collections.Generic;

namespace Hack.VMTranslator.Lib.Models
{
    public interface IOutputCode
    {
        IOutputCode AppendCode(IOutputCode code);
        IEnumerable<string> GetLines();
    }
}