using Hack.VMTranslator.Lib.Input;
using Hack.VMTranslator.Lib.Models;

namespace Hack.VMTranslator.Lib.Commands
{
    public interface ICommandTranslator
    {
        IOutputCode Translate(VMCodeLine vmCommand);
    }
}