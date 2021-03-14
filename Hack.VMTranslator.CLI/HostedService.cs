using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Hack.VMTranslator.Lib.Input;
using Hack.VMTranslator.Lib.Models;
using Hack.VMTranslator.Lib.Output;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Hack.VMTranslator.CLI
{
    public class HostedService : BackgroundService
    {
        public HostedService(Lib.VMTranslator translator, VmFileLoaderFactory fileLoader,
            VmDirectoryLoaderFactory directoryLoader, FileSaver saver,
            IOptions<HostedServiceOptions> options, IHostApplicationLifetime applicationLifetime)
        {
            _translator = translator ?? throw new ArgumentNullException(nameof(translator));
            _fileLoaderFactory = fileLoader ?? throw new ArgumentNullException(nameof(fileLoader));
            _directoryLoaderFactory = directoryLoader ?? throw new ArgumentNullException(nameof(directoryLoader));
            _saver = saver ?? throw new ArgumentNullException(nameof(saver));
            _options = options.Value;
            _applicationLifetime = applicationLifetime ?? throw new ArgumentNullException(nameof(applicationLifetime));
        }

        private readonly Lib.VMTranslator _translator;
        private readonly VmFileLoaderFactory _fileLoaderFactory;
        private readonly VmDirectoryLoaderFactory _directoryLoaderFactory;
        private readonly FileSaver _saver;
        private readonly HostedServiceOptions _options;
        private readonly IHostApplicationLifetime _applicationLifetime;
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            IOutputCode result;
            if (File.Exists(_options.InputPath.FullName))
            {
                result = await HandleSingleFileInput(stoppingToken);
            }
            else
            {
                result = await HandleDirectoryInput(stoppingToken);
            }
            
            await _saver.Save(result.GetLines(), _options.OutputPath, stoppingToken);
            
            _applicationLifetime.StopApplication();
        }

        private async Task<IOutputCode> HandleSingleFileInput(CancellationToken stoppingToken)
        {
            var loader = _fileLoaderFactory.Create(_options.InputPath.FullName);
            var input = await loader.Load(stoppingToken);
            var result = _translator.Translate(input);
            return result;
        }

        private async Task<IOutputCode> HandleDirectoryInput(CancellationToken stoppingToken)
        {
            var loader = _directoryLoaderFactory.Create(new DirectoryInfo(_options.InputPath.FullName));
            var result = new AsmCode();
            var file = await loader.LoadNextFile(stoppingToken);
            while (file is not null)
            {
                var code = _translator.Translate(file);
                result.AppendCode(code);
                file = await loader.LoadNextFile(stoppingToken);
            }
            return result;
        }
    }
}