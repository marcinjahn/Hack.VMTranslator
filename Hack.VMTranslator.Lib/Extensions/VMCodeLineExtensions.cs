using Hack.VMTranslator.Lib.Input;
using Hack.VMTranslator.Lib.Models;

namespace Hack.VMTranslator.Lib.Extensions
{
    public static class VMCodeLineExtensions
    {
        public static string GetFirstArgument(this VMCodeLine codeLine)
        {
            return codeLine.Code.Split(' ')[1];
        }
        
        public static string GetSecondArgument(this VMCodeLine codeLine)
        {
            return codeLine.Code.Split(' ')[2];
        }
    }
}