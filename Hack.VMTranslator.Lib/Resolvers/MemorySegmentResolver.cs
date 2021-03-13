using System;
using Hack.VMTranslator.Lib.Input;
using Hack.VMTranslator.Lib.Models;

namespace Hack.VMTranslator.Lib.Resolvers
{
    public class MemorySegmentResolver
    {
        public MemorySegment Resolve(VMCodeLine line)
        {
            if (line.Code.Contains("local"))
            {
                return MemorySegment.Local;
            }
            else if (line.Code.Contains("argument"))
            {
                return MemorySegment.Argument;
            }
            else if (line.Code.Contains("pointer"))
            {
                return MemorySegment.Pointer;
            }
            else if (line.Code.Contains("static"))
            {
                return MemorySegment.Static;
            }
            else if (line.Code.Contains("temp"))
            {
                return MemorySegment.Temp;
            }
            else if (line.Code.Contains("this"))
            {
                return MemorySegment.This;
            }
            else if (line.Code.Contains("that"))
            {
                return MemorySegment.That;
            }
            else if (line.Code.Contains("constant"))
            {
                return MemorySegment.Constant;
            }
            else
            {
                throw new ArgumentException("Supplied code line does not contain a supported memory segment",
                    nameof(line));
            }
        }
    }
}