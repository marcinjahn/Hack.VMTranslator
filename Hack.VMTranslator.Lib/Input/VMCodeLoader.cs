using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Hack.VMTranslator.Lib.Input
{
    public class VMCodeLoader
    {
        private readonly VMCodeLoaderOptions _options;
        private readonly LineCleaner _cleaner;

        public VMCodeLoader(IOptions<VMCodeLoaderOptions> options, LineCleaner cleaner)
        {
            _cleaner = cleaner ?? throw new ArgumentNullException(nameof(cleaner));
            _options = options.Value;
        }

        public async Task<IReadOnlyCollection<VMCodeLine>> Load(CancellationToken cancellationToken)
        {
            var rawLines = await File.ReadAllLinesAsync(_options.InputPath, cancellationToken);
            var cleanLines = Clean(rawLines);
            
            var result = new List<VMCodeLine>();
            foreach (var line in cleanLines)
            {
                line.AddTo(result);
            }

            return result;
        }

        private IEnumerable<IInputCodeLine> Clean(IEnumerable<string> lines)
        {
            return lines.Select(line => _cleaner.Clean(line));
        }
    }
}