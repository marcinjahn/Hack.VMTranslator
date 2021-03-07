using System;
using Hack.VMTranslator.Lib.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Hack.VMTranslator.Lib.Commands.PopSegments
{
    public class PopTranslatorFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public PopTranslatorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }
        
        public ICommandTranslator GetTranslator(MemorySegment memorySegment)
        {
            return memorySegment switch
            {
                MemorySegment.Local => _serviceProvider.GetRequiredService<PopLocalTranslator>(),
                MemorySegment.Argument => _serviceProvider.GetRequiredService<PopArgumentTranslator>(),
                MemorySegment.This => _serviceProvider.GetRequiredService<PopThisTranslator>(),
                MemorySegment.That => _serviceProvider.GetRequiredService<PopThatTranslator>(),
                MemorySegment.Pointer => _serviceProvider.GetRequiredService<PopPointerTranslator>(),
                MemorySegment.Static => _serviceProvider.GetRequiredService<PopStaticTranslator>(),
                MemorySegment.Temp => _serviceProvider.GetRequiredService<PopTempTranslator>(),
                _ => throw new ArgumentOutOfRangeException(nameof(memorySegment), memorySegment, null)
            };
        }
    }
}