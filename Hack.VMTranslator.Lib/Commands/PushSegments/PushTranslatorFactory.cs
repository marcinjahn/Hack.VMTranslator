using System;
using Hack.VMTranslator.Lib.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Hack.VMTranslator.Lib.Commands.PushSegments
{
    public class PushTranslatorFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public PushTranslatorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }
        
        public ICommandTranslator GetTranslator(MemorySegment memorySegment)
        {
            return memorySegment switch
            {
                MemorySegment.Local => _serviceProvider.GetRequiredService<PushLocalTranslator>(),
                MemorySegment.Argument => _serviceProvider.GetRequiredService<PushArgumentTranslator>(),
                MemorySegment.This => _serviceProvider.GetRequiredService<PushThisTranslator>(),
                MemorySegment.That => _serviceProvider.GetRequiredService<PushThatTranslator>(),
                MemorySegment.Pointer => _serviceProvider.GetRequiredService<PushPointerTranslator>(),
                MemorySegment.Static => _serviceProvider.GetRequiredService<PushStaticTranslator>(),
                MemorySegment.Temp => _serviceProvider.GetRequiredService<PushTempTranslator>(),
                MemorySegment.Constant => _serviceProvider.GetRequiredService<PushConstantTranslator>(),
                _ => throw new ArgumentOutOfRangeException(nameof(memorySegment), memorySegment, null)
            };
        }
    }
}