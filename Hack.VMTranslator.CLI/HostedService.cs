using System;
using System.Threading;
using System.Threading.Tasks;
using Hack.VMTranslator.Lib.Input;
using Hack.VMTranslator.Lib.Output;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Hack.VMTranslator.CLI
{
    public class HostedService : BackgroundService
    {
        public HostedService(Lib.VMTranslator translator, VMCodeLoader loader, FileSaver saver,
            IOptions<HostedServiceOptions> options, IHostApplicationLifetime applicationLifetime)
        {
            _translator = translator ?? throw new ArgumentNullException(nameof(translator));
            _loader = loader ?? throw new ArgumentNullException(nameof(loader));
            _saver = saver ?? throw new ArgumentNullException(nameof(saver));
            _options = options.Value;
            _applicationLifetime = applicationLifetime ?? throw new ArgumentNullException(nameof(applicationLifetime));
        }

        private readonly Lib.VMTranslator _translator;
        private readonly VMCodeLoader _loader;
        private readonly FileSaver _saver;
        private readonly HostedServiceOptions _options;
        private readonly IHostApplicationLifetime _applicationLifetime;
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var input = await _loader.Load(stoppingToken);
            var result = _translator.Translate(input);
            await _saver.Save(result.GetLines(), _options.OutputPath, stoppingToken);
            
            _applicationLifetime.StopApplication();
        }
    }
}