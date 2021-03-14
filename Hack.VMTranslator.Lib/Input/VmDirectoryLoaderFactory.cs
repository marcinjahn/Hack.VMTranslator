using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Hack.VMTranslator.Lib.Input
{
    public class VmDirectoryLoaderFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public VmDirectoryLoaderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public VmDirectoryLoader Create(DirectoryInfo directoryPath)
        {
            return new VmDirectoryLoader(
                _serviceProvider.GetRequiredService<VmFileLoaderFactory>(),
                new OptionsWrapper<VmDirectoryLoaderOptions>(
                    new VmDirectoryLoaderOptions
                    {
                        DirectoryPath = directoryPath
                    }));
        }
    }
}