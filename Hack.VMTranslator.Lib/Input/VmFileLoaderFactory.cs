using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Hack.VMTranslator.Lib.Input
{
    public class VmFileLoaderFactory
    {
        private readonly IServiceProvider _provider;

        public VmFileLoaderFactory(IServiceProvider provider)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        public VmFileLoader Create(string filePath)
        {
            return new VmFileLoader(
                new OptionsWrapper<VmCodeLoaderOptions>(
                    new VmCodeLoaderOptions
                    {
                        InputPath = filePath
                    }),
                _provider.GetRequiredService<InputCodeLineFactory>());
        }
    }
}